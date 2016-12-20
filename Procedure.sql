USE [ZHXTV3META]
GO

/****** Object:  Table [dbo].[SequenceTable]    Script Date: 2016/12/20 11:24:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SequenceTable](
	[Sequence] [float] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO



USE [ZHXTV3META]
GO

/****** Object:  StoredProcedure [dbo].[GetSequence]    Script Date: 2016/12/20 11:41:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetSequence]
@value int=0 output
AS
    declare @maxValue int;
    SELECT @maxValue=MAX(Sequence) 
    FROM Sequencetable;
    if @maxValue is null
      set @maxValue=0;
    else
    begin
    delete  from sequencetable;
	end;
    set @maxValue=@maxValue+1;
    insert into Sequencetable (sequence) values(@maxValue)
	set @value=@maxValue;
GO