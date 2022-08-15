USE Track
GO
DROP TABLE IF EXISTS [dbo].[TrackLocation];
GO
DROP FUNCTION IF EXISTS geodist;
GO
DROP PROCEDURE IF EXISTS show_sum_statistics_by_id;
GO
DROP PROCEDURE IF EXISTS show_top_statistics_by_id;