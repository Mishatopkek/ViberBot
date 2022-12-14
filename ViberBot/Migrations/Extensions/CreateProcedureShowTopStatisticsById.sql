USE Track
GO
DROP PROCEDURE IF EXISTS show_top_statistics_by_id;
GO
CREATE PROCEDURE show_top_statistics_by_id @user_IMEI VARCHAR(50)
AS
BEGIN
    --Declare temp date
    DECLARE @previous_latitude decimal(12, 9), @previous_longitude decimal(12, 9), @previous_date datetime
    DECLARE @current_latitude decimal(12, 9), @current_longitude decimal(12, 9), @current_date datetime
    DECLARE @distance DECIMAL(6,2) = 0
    DECLARE @time_long INT = 0
    DECLARE @temp_date_diff INT
    DECLARE @walk_table TABLE (ID INT IDENTITY(1,1), distance DECIMAL(6,2), time_length_second int)

    --Declare CURSOR
    DECLARE track_cursor CURSOR LOCAL FOR
        SELECT
            latitude,
            longitude,
            date_track,
            LAG(CAST(latitude AS DECIMAL(12, 9))) OVER (ORDER BY date_track) AS prev_latitude,
            LAG(CAST(longitude AS DECIMAL(12, 9))) OVER (ORDER BY date_track) AS prev_longitude,
            LAG(date_track) OVER (ORDER BY date_track) AS prev_date
        FROM TrackLocation
        WHERE IMEI = @user_IMEI;

    OPEN track_cursor

    FETCH NEXT FROM track_cursor
        INTO @current_latitude, @current_longitude, @current_date, @previous_latitude, @previous_longitude, @previous_date;

    --If you need to calculate time each walk
    WHILE @@FETCH_STATUS = 0
        BEGIN
            SET @temp_date_diff = DATEDIFF(second , @previous_date, @current_date);
            IF  @temp_date_diff < 1800
                BEGIN
                    SET @distance = @distance + dbo.geodist (@previous_latitude, @previous_longitude,
                                                             @current_latitude, @current_longitude)
                    SET @time_long = @time_long + @temp_date_diff
                END
            ELSE
                BEGIN
                    IF @distance <> 0
                        BEGIN
                            INSERT INTO @walk_table(distance, time_length_second)
                            VALUES (@distance, @time_long)
                            SET @distance = 0
                            SET @time_long = 0
                        END
                END

            FETCH NEXT FROM track_cursor
                INTO @current_latitude, @current_longitude, @current_date, @previous_latitude, @previous_longitude, @previous_date;
        END;

    CLOSE track_cursor

    --TODO top 10 hard-coded, it's necessary to solve 
    SELECT TOP 10 ID, distance, DATEADD(SECOND, time_length_second, '1900/01/01') AS time_length
    FROM @walk_table
    ORDER BY distance desc
END
GO