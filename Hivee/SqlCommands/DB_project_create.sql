CREATE DATABASE SocialMedia;
GO

USE SocialMedia;
GO

CREATE TABLE [User] (
    User_id     INT PRIMARY KEY,
    Bio         VARCHAR(500),
    Private     BIT,
    Birth_date  DATE,
    Email       VARCHAR(255) UNIQUE NOT NULL,
    Avatar_url  VARCHAR(500),
    First_name  VARCHAR(100),
    Last_name   VARCHAR(100),
    password    VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Page (
    Page_id       INT PRIMARY KEY,
    Page_name     VARCHAR(255),
    Description   TEXT,
    Creation_date DATE,
    Creator_id    INT,
    FOREIGN KEY (Creator_id) REFERENCES [User](User_id)
);
GO

CREATE TABLE Post (
    Post_id           INT PRIMARY KEY,
    User_ID           INT,
    Page_id           INT NULL,
    Text_Content      TEXT,
    Publish_Timestamp DATETIME,
    Media_path        VARCHAR(500) NULL
    FOREIGN KEY (User_ID) REFERENCES [User](User_id),
    FOREIGN KEY (Page_id) REFERENCES Page(Page_id)
);
GO

CREATE TABLE Event (
    Event_id   INT PRIMARY KEY,
    Creator_id INT,
    Start_time DATETIME,
    End_time   DATETIME,
    Title      VARCHAR(255),
    FOREIGN KEY (Creator_id) REFERENCES [User](User_id)
);
GO

CREATE TABLE Message (
    Message_id   INT PRIMARY KEY,
    Message_body TEXT,
    Timestamp    DATETIME,
);
GO

CREATE TABLE Comment (
    Comment_seq        INT,
    Post_id            INT,
    User_ID            INT,
    Text_content       TEXT,
    Creation_timestamp DATETIME,
    PRIMARY KEY (Comment_seq, Post_id),
    FOREIGN KEY (Post_id) REFERENCES Post(Post_id),
    FOREIGN KEY (User_ID) REFERENCES [User](User_id)
);
GO

CREATE TABLE Participate (
    User_id  INT,
    Event_id INT,
    PRIMARY KEY (User_id, Event_id),
    FOREIGN KEY (User_id)  REFERENCES [User](User_id),
    FOREIGN KEY (Event_id) REFERENCES Event(Event_id)
);
GO

CREATE TABLE DM (
    Suser_id   INT,
    Ruser_id   INT,
    Message_id INT,
    PRIMARY KEY (Suser_id, Ruser_id, Message_id),
    FOREIGN KEY (Suser_id)   REFERENCES [User](User_id),
    FOREIGN KEY (Ruser_id)   REFERENCES [User](User_id),
    FOREIGN KEY (Message_id) REFERENCES Message(Message_id)
);
GO

CREATE TABLE Follow (
    Follower_user_id  INT,
    Followed_user_id  INT,
    PRIMARY KEY (Follower_user_id, Followed_user_id),
    FOREIGN KEY (Follower_user_id) REFERENCES [User](User_id),
    FOREIGN KEY (Followed_user_id) REFERENCES [User](User_id)
);
GO

CREATE TABLE Join_Page (
    User_id   INT,
    Page_id   INT,
    Join_date DATE,
    Role      VARCHAR(50),
    PRIMARY KEY (User_id, Page_id),
    FOREIGN KEY (User_id) REFERENCES [User](User_id),
    FOREIGN KEY (Page_id) REFERENCES Page(Page_id)
);
GO

CREATE TABLE Location (
    Event_id INT,
    ZIP      VARCHAR(20),
    Street   VARCHAR(255),
    PRIMARY KEY (Event_id, ZIP, Street),
    FOREIGN KEY (Event_id) REFERENCES Event(Event_id)
);
GO

CREATE TABLE Phone_Number (
    User_id     INT,
    phonenumber VARCHAR(20),
    PRIMARY KEY (User_id, phonenumber),
    FOREIGN KEY (User_id) REFERENCES [User](User_id)
);
GO

CREATE TABLE Attachment_type_Message (
    Message_id       INT,
    Attachement_type VARCHAR(100),
    Media_path   VARCHAR(500) NULL,
    PRIMARY KEY (Message_id, Attachement_type),
    FOREIGN KEY (Message_id) REFERENCES Message(Message_id)
);
GO

CREATE TABLE Hashtag (
    Hashtag VARCHAR(100),
    Post_id INT,
    PRIMARY KEY (Hashtag, Post_id),
    FOREIGN KEY (Post_id) REFERENCES Post(Post_id)
);
GO