CREATE PROCEDURE [dbo].[sp_get_similar_photo] @param1 varchar(8)
AS

BEGIN

;WITH CTETable (ImgPath, Distance, Dph)
AS (
SELECT id.path, dbo.f_get_distance(@param1, id.dph) AS result, id.dph 
FROM Images id
)

SELECT ImgPath
FROM CTETable
WHERE Distance <=4
ORDER BY Distance Asc;
END

RETURN