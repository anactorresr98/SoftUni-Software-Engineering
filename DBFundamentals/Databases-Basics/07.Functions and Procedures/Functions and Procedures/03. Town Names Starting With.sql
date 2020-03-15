CREATE OR ALTER PROC usp_GetTownsStartingWith(@Description VARCHAR(50)) 
         AS
	 SELECT Name
	   FROM Towns 
	  WHERE LEFT(Name,LEN(@Text)) = @Description

EXEC dbo.usp_GetTownsStartingWith 'BELL'
