﻿CREATE TABLE [dbo].[Assoc_MovieGenre] (
    [MovieId] INT NOT NULL,
    [GenreId] INT NOT NULL,
    CONSTRAINT [FK_Assoc_MovieGenre_Genre] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genre] ([Id]),
    CONSTRAINT [FK_Assoc_MovieGenre_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);