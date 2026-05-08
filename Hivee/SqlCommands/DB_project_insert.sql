INSERT INTO [User] VALUES
(1, 'Love coding', 0, '1995-03-15', 'ahmed@email.com', 'avatar1.jpg', 'Ahmed', 'Ali', 'pass123'),
(2, 'Traveler', 1, '1998-07-22', 'sara@email.com', 'avatar2.jpg', 'Sara', 'Mohamed', 'pass456'),
(3, 'Engineer', 0, '2000-01-10', 'omar@email.com', 'avatar3.jpg', 'Omar', 'Hassan', 'pass789');
GO

INSERT INTO Page VALUES
(1, 'Tech World', 'All about technology', '2026-01-15', 3),
(2, 'Travel Vibes', 'Travel tips and photos', '2025-03-20', 2),
(3, 'ASUFE', 'ASUFE Announcements', '2023-06-10', 1);
GO

INSERT INTO Post VALUES
(1, 1, 1,    'Check out this new framework!', '2024-01-10 10:00:00', 'media/post1.jpg'),
(2, 1, 2,    'Best beaches in Egypt!',   '2025-02-15 14:30:00', 'media/post2.jpg'),
(3, 3, NULL, 'New project is live!', '2026-03-20 18:00:00', 'media/post3.jpg');
GO

INSERT INTO Event VALUES
(1, 1, '2026-05-11 09:00:00', '2026-05-11 17:00:00', 'Tech Conference'),
(2, 2, '2026-06-15 10:00:00', '2026-06-15 20:00:00', 'Travel Meetup'),
(3, 3, '2026-07-20 12:00:00', '2026-07-20 16:00:00', 'AI Tools Workshop');
GO

INSERT INTO Message VALUES
(1, 'Hey! How are you?',         '2026-01-10 11:00:00'),
(2, 'I''m fine! What about you?', '2026-01-10 11:10:00'),
(3, 'Check this photo!',         '2026-01-11 12:00:00'),
(4, 'How was the event, Sara?',  '2026-07-21 09:30:00'),
(5, 'It was great! I enhanced this photo using an AI tool!', '2026-07-21 09:35:00'),
(6, 'If you will attend the AI Tools Workshop, please fill this document', '2026-07-13 14:10:00');
GO

INSERT INTO Comment VALUES
(1, 1, 2, 'Great post!',         '2024-01-10 11:00:00'),
(2, 1, 3, 'Very informative!',   '2024-01-10 12:00:00'),
(1, 2, 1, 'Beautiful place!',    '2025-02-15 15:00:00');
GO

INSERT INTO Participate VALUES
(1, 3),
(2, 3),
(1, 2),
(3, 2),
(3, 1);
GO

INSERT INTO DM VALUES
(1, 2, 1),
(2, 1, 2),
(2, 1, 3),
(3, 2, 4),
(2, 3, 5),
(3, 1, 6);
GO

INSERT INTO Follow VALUES
(1, 2),
(1, 3),
(2, 1),
(2, 3),
(3, 1),
(3, 2);
GO

INSERT INTO Join_Page VALUES
(1, 1, '2023-01-15', 'Admin'),
(1, 2, '2023-03-20', 'Member'),
(3, 3, '2023-06-10', 'Member');
GO

INSERT INTO Location VALUES
(1, '12345', '123 Tahrir St, Cairo'),
(1, '11111', '789 Nile St, Giza'),
(2, '54321', '456 Corniche St, Alexandria'),
(3, '99999', '321 Ramses St, Cairo');
GO

INSERT INTO Phone_Number VALUES
(1, '01012345678'),
(2, '01098765432'),
(3, '01156789012');
GO

INSERT INTO Attachment_type_Message VALUES
(3, 'Image', 'media/msg3.jpg'),
(5, 'Image', 'media/msg5.jpg'),
(6, 'File', 'media/msg6.pdf');
GO

INSERT INTO Hashtag VALUES
('Technology', 1),
('frameworks', 1),
('Programming', 1),
('Travel',     2),
('Egypt',      2);
GO