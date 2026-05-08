
-- Get members of a page with their roles
CREATE FUNCTION GetPageMembers(@Page_id INT)
RETURNS TABLE
AS
RETURN (
    SELECT jp.User_id,
           jp.Page_id,
           jp.Join_date,
           jp.Role,
           u.First_name + ' ' + u.Last_name AS FullName
    FROM   Join_Page jp
    JOIN   [User] u ON u.User_id = jp.User_id
    WHERE  jp.Page_id = @Page_id
);
GO

-- Get pages a specific user has joined
CREATE FUNCTION GetPagesByUser(@User_id INT)
RETURNS TABLE
AS
RETURN (
    SELECT p.Page_id,
           p.Page_name,
           p.Description,
           p.Creation_date,
           p.Creator_id,
           u.First_name + ' ' + u.Last_name AS CreatorName,
           jp.Role
    FROM   Join_Page jp
    JOIN   Page       p ON p.Page_id   = jp.Page_id
    JOIN   [User]     u ON u.User_id   = p.Creator_id
    WHERE  jp.User_id = @User_id
);
GO

--  INSERT Stored Procedures


-- Add a new page  (creator auto-joins as Admin inside a transaction)
CREATE PROCEDURE AddPage
    @Page_name   VARCHAR(255),
    @Description TEXT,
    @Creator_id  INT
AS
BEGIN
    DECLARE @NewPageId INT = (SELECT ISNULL(MAX(Page_id), 0) + 1 FROM Page);

    INSERT INTO Page (Page_id, Page_name, Description, Creation_date, Creator_id)
    VALUES (@NewPageId, @Page_name, @Description, CAST(GETDATE() AS DATE), @Creator_id);

    -- Auto-join creator as Admin
    INSERT INTO Join_Page (User_id, Page_id, Join_date, Role)
    VALUES (@Creator_id, @NewPageId, CAST(GETDATE() AS DATE), 'Admin');

    SELECT @NewPageId AS NewPageId;   -- return the new ID to the caller
END;
GO

-- Join a page as Member
CREATE PROCEDURE JoinPage
    @User_id INT,
    @Page_id INT
AS
BEGIN
    INSERT INTO Join_Page (User_id, Page_id, Join_date, Role)
    VALUES (@User_id, @Page_id, CAST(GETDATE() AS DATE), 'Member');
END;
GO

--  UPDATE Stored Procedures

-- Update page name and description
CREATE PROCEDURE UpdatePage
    @Page_id     INT,
    @Page_name   VARCHAR(255),
    @Description TEXT
AS
BEGIN
    UPDATE Page
    SET    Page_name   = @Page_name,
           Description = @Description
    WHERE  Page_id = @Page_id;
END;
GO

-- Update a member's role (Admin ↔ Member)
CREATE PROCEDURE UpdateMemberRole
    @User_id INT,
    @Page_id INT,
    @Role    VARCHAR(50)
AS
BEGIN
    UPDATE Join_Page
    SET    Role = @Role
    WHERE  User_id = @User_id AND Page_id = @Page_id;
END;
GO

--  DELETE Stored Procedures

-- Delete a page 
CREATE PROCEDURE DeletePage
    @Page_id INT
AS
BEGIN
    DELETE FROM Join_Page WHERE Page_id = @Page_id;
    DELETE FROM Post      WHERE Page_id = @Page_id;
    DELETE FROM Page      WHERE Page_id = @Page_id;
END;
GO

-- Remove one member from a page
CREATE PROCEDURE LeavePage
    @User_id INT,
    @Page_id INT
AS
BEGIN
    DELETE FROM Join_Page
    WHERE  User_id = @User_id AND Page_id = @Page_id;
END;
GO

