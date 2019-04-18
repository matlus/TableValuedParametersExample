CREATE PROCEDURE [dbo].[CreateMovies]
	@MovieTvp MovieTvp READONLY
AS
	SET NOCOUNT ON
	SET IDENTITY_INSERT dbo.Movie ON

	-- Insert Distinct Genres into the Genre table
	INSERT
	INTO	dbo.Genre
	SELECT	DISTINCT Genre
	FROM	@MovieTvp

	-- Insert Movies into the Movie Table
	INSERT
	INTO	dbo.Movie (Id, Title, [Year], ImageUrl)
	SELECT	ROW_Number() OVER (ORDER BY Title) Id, Title, [Year], ImageUrl
	FROM	@MovieTvp m
	
	-- Select the Movie.Id and the Genre.Id columns and insert into the Assoc_MovieGenre
	INSERT
	INTO	dbo.Assoc_MovieGenre
	SELECT	dbo.Movie.Id, dbo.Genre.Id
	FROM	@MovieTvp mtvp
	INNER
	JOIN	dbo.Genre
	ON		dbo.Genre.Title = mtvp.Genre
	INNER
	JOIN	dbo.Movie
	ON		dbo.Movie.Title = mtvp.Title

	SET IDENTITY_INSERT dbo.Movie OFF
	SET NOCOUNT OFF


RETURN 0