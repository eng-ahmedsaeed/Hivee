-- =====================
-- SELECT Functions
-- =====================

-- Get all users
CREATE FUNCTION GetAllUsers()
RETURNS TABLE
AS
RETURN (
    SELECT * FROM [User]
);
GO

-- Get user by ID
CREATE FUNCTION GetUserById(@User_id INT)
RETURNS TABLE
AS
RETURN (
    SELECT * FROM [User] WHERE User_id = @User_id
);
GO

-- Get posts by page
CREATE FUNCTION GetPostsByPage(@Page_id INT)
RETURNS TABLE
AS
RETURN (
    SELECT p.Post_id, p.Text_Content, p.Publish_Timestamp, p.Media_path,
           u.First_name, u.Last_name
    FROM Post p
    JOIN [User] u ON p.User_ID = u.User_id
    WHERE p.Page_id = @Page_id
);
GO


-- Get posts by user
CREATE FUNCTION GetPostsByUser(@User_id INT)
RETURNS TABLE
AS
RETURN (
    SELECT p.Post_id, p.Text_Content, p.Publish_Timestamp, p.Media_path,
           pg.Page_name
    FROM Post p
    LEFT JOIN Page pg ON p.Page_id = pg.Page_id
    WHERE p.User_ID = @User_id
);
GO

-- feed
CREATE FUNCTION GetPostsByFollowing(@User_id INT)
RETURNS TABLE
AS
RETURN (
    SELECT p.Post_id, p.Text_Content, p.Publish_Timestamp, p.Media_path,
           u.First_name, u.Last_name
    FROM Post p
    JOIN [User] u ON p.User_ID = u.User_id
    WHERE p.User_ID IN (
        SELECT Followed_user_id
        FROM Follow
        WHERE Follower_user_id = @User_id
    )
);
GO

-- Get comments by post
CREATE FUNCTION GetCommentsByPost(@Post_id INT)
RETURNS TABLE
AS
RETURN (
    SELECT c.Comment_seq, c.Text_content, c.Creation_timestamp,
           u.First_name, u.Last_name
    FROM Comment c
    JOIN [User] u ON c.User_ID = u.User_id
    WHERE c.Post_id = @Post_id
);
GO

-- Get all pages
CREATE FUNCTION GetAllPages()
RETURNS TABLE
AS
RETURN (
    SELECT pg.Page_id, pg.Page_name, pg.Description, pg.Creation_date,
           u.First_name, u.Last_name
    FROM Page pg
    JOIN [User] u ON pg.Creator_id = u.User_id
);
GO

-- Get all events
CREATE FUNCTION GetAllEvents()
RETURNS TABLE
AS
RETURN (
    SELECT e.Event_id, e.Title, e.Start_time, e.End_time,
           u.First_name, u.Last_name
    FROM Event e
    JOIN [User] u ON e.Creator_id = u.User_id
);
GO

-- Get DMs between two users
CREATE FUNCTION GetDMsBetweenUsers(@User1 INT, @User2 INT)
RETURNS TABLE
AS
RETURN (
    SELECT m.Message_id, m.Message_body, m.Timestamp,
           d.Suser_id, d.Ruser_id,
           a.Attachement_type, a.Media_path
    FROM DM d
    JOIN Message m ON d.Message_id = m.Message_id
    LEFT JOIN Attachment_type_Message a ON m.Message_id = a.Message_id
    WHERE (d.Suser_id = @User1 AND d.Ruser_id = @User2)
       OR (d.Suser_id = @User2 AND d.Ruser_id = @User1)
);
GO

-- Get followers of a user
CREATE FUNCTION GetFollowers(@User_id INT)
RETURNS TABLE
AS
RETURN (
    SELECT u.User_id, u.First_name, u.Last_name, u.Avatar_url
    FROM Follow f
    JOIN [User] u ON f.Follower_user_id = u.User_id
    WHERE f.Followed_user_id = @User_id
);
GO

-- Get following of a user
CREATE FUNCTION GetFollowing(@User_id INT)
RETURNS TABLE
AS
RETURN (
    SELECT u.User_id, u.First_name, u.Last_name, u.Avatar_url
    FROM Follow f
    JOIN [User] u ON f.Followed_user_id = u.User_id
    WHERE f.Follower_user_id = @User_id
);
GO

-- =====================
-- INSERT Stored Procedures
-- =====================

-- Add new user
CREATE PROCEDURE AddUser
    @Bio VARCHAR(500), @Private BIT, @Birth_date DATE,
    @Email VARCHAR(255), @Avatar_url VARCHAR(500),
    @First_name VARCHAR(100), @Last_name VARCHAR(100), @Password VARCHAR(255)
AS
BEGIN
    INSERT INTO [User] (User_id, Bio, Private, Birth_date, Email, Avatar_url, First_name, Last_name, password)
    VALUES ((SELECT ISNULL(MAX(User_id), 0) + 1 FROM [User]),
            @Bio, @Private, @Birth_date, @Email, @Avatar_url, @First_name, @Last_name, @Password)
END;
GO

-- Add new post
CREATE PROCEDURE AddPost
    @User_ID INT, @Page_id INT = NULL,
    @Text_Content TEXT, @Media_path VARCHAR(500) = NULL
AS
BEGIN
    INSERT INTO Post (Post_id, User_ID, Page_id, Text_Content, Publish_Timestamp, Media_path)
    VALUES ((SELECT ISNULL(MAX(Post_id), 0) + 1 FROM Post),
            @User_ID, @Page_id, @Text_Content, GETDATE(), @Media_path)
END;
GO

-- Add new comment
CREATE PROCEDURE AddComment
    @Post_id INT, @User_ID INT, @Text_content TEXT
AS
BEGIN
    INSERT INTO Comment (Comment_seq, Post_id, User_ID, Text_content, Creation_timestamp)
    VALUES ((SELECT ISNULL(MAX(Comment_seq), 0) + 1 FROM Comment WHERE Post_id = @Post_id),
            @Post_id, @User_ID, @Text_content, GETDATE())
END;
GO

-- Add new event
CREATE PROCEDURE AddEvent
    @Creator_id INT, @Start_time DATETIME,
    @End_time DATETIME, @Title VARCHAR(255)
AS
BEGIN
    INSERT INTO Event (Event_id, Creator_id, Start_time, End_time, Title)
    VALUES ((SELECT ISNULL(MAX(Event_id), 0) + 1 FROM Event),
            @Creator_id, @Start_time, @End_time, @Title)
END;
GO

-- Send DM
CREATE PROCEDURE SendDM
    @Suser_id INT, @Ruser_id INT,
    @Message_body TEXT,
    @Media_path VARCHAR(500) = NULL,
    @Attachment_type VARCHAR(100) = 'Image'
AS
BEGIN
    DECLARE @Message_id INT = (SELECT ISNULL(MAX(Message_id), 0) + 1 FROM Message)
    INSERT INTO Message (Message_id, Message_body, Timestamp)
    VALUES (@Message_id, @Message_body, GETDATE())

    INSERT INTO DM (Suser_id, Ruser_id, Message_id)
    VALUES (@Suser_id, @Ruser_id, @Message_id)

    IF @Media_path IS NOT NULL
    BEGIN
        INSERT INTO Attachment_type_Message (Message_id, Attachement_type, Media_path)
        VALUES (@Message_id, @Attachment_type, @Media_path)
    END
END;
GO

-- Follow user
CREATE PROCEDURE FollowUser
    @Follower_user_id INT, @Followed_user_id INT
AS
BEGIN
    INSERT INTO Follow (Follower_user_id, Followed_user_id)
    VALUES (@Follower_user_id, @Followed_user_id)
END;
GO

-- =====================
-- UPDATE Stored Procedures
-- =====================

-- Update user profile
CREATE PROCEDURE UpdateUserProfile
    @User_id INT, @Bio VARCHAR(500),
    @Private BIT, @Avatar_url VARCHAR(500)
AS
BEGIN
    UPDATE [User]
    SET Bio = @Bio, Private = @Private, Avatar_url = @Avatar_url
    WHERE User_id = @User_id
END;
GO

-- Update post
CREATE PROCEDURE UpdatePost
    @Post_id INT, @Text_Content TEXT, @Media_path VARCHAR(500) = NULL
AS
BEGIN
    UPDATE Post
    SET Text_Content = @Text_Content, Media_path = @Media_path
    WHERE Post_id = @Post_id
END;
GO

-- update event 
CREATE PROCEDURE UpdateEvent
    @Event_id  INT,
    @Title     VARCHAR(255),
    @Start_time DATETIME,
    @End_time   DATETIME,
    @Old_ZIP   VARCHAR(20),
    @Old_Street VARCHAR(255),
    @New_ZIP   VARCHAR(20),
    @New_Street VARCHAR(255)
AS
BEGIN
    UPDATE Event
    SET Title = @Title, Start_time = @Start_time, End_time = @End_time
    WHERE Event_id = @Event_id

    UPDATE Location
    SET ZIP = @New_ZIP, Street = @New_Street
    WHERE Event_id = @Event_id 
      AND ZIP = @Old_ZIP 
      AND Street = @Old_Street
END;
GO

-- =====================
-- DELETE Stored Procedures
-- =====================

-- Delete user
CREATE PROCEDURE DeleteUser
    @User_id INT
AS
BEGIN
    DELETE FROM [User] WHERE User_id = @User_id
END;
GO

-- Delete post
CREATE PROCEDURE DeletePost
    @Post_id INT
AS
BEGIN
    DELETE FROM Post WHERE Post_id = @Post_id
END;
GO

-- Delete comment
CREATE PROCEDURE DeleteComment
    @Comment_seq INT, @Post_id INT
AS
BEGIN
    DELETE FROM Comment
    WHERE Comment_seq = @Comment_seq AND Post_id = @Post_id
END;
GO

-- Unfollow user
CREATE PROCEDURE UnfollowUser
    @Follower_user_id INT, @Followed_user_id INT
AS
BEGIN
    DELETE FROM Follow
    WHERE Follower_user_id = @Follower_user_id
      AND Followed_user_id = @Followed_user_id
END;
GO

-- Delete event
CREATE PROCEDURE DeleteEvent
    @Event_id INT
AS
BEGIN
    DELETE FROM Event WHERE Event_id = @Event_id
END;
GO

