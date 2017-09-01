
create PROCEDURE [dbo].[proPaging]
  @TableName nvarchar(50)=null, --����
  @OrderBy nvarchar(100)=null, --������SQL��䣬���磨CreatedDate DESC,LastAlterDate ASC��
  @ColumnList nvarchar(500)='*',--Ҫ��ѯ�����ֶ��б�,*��ʾȫ���ֶ�
  @PageSize int=10,        --ÿҳ��¼��
  @PageIndex int=1,         --ָ��ҳ
  @Condition nvarchar(max)=null,--��ѯ����
  @PageCount int=0 OUTPUT,   --��ҳ��
  @RecordCount int=0 OUTPUT   --�ܼ�¼��
 
AS

SET @TableName='['+@TableName+'] WITH(NOLOCK) '
DECLARE @sql nvarchar(max),@where nvarchar(max)

IF @Condition is null or rtrim(@Condition)=''
BEGIN--û�в�ѯ����
  SET @Condition=' IsDeleted=0 '
END
ELSE
BEGIN--�в�ѯ����
  SET @Condition=' '+@Condition+' AND IsDeleted=0 '
END
 
SET @where=' WHERE ('+@Condition+') '--ԭ��û�����������ϴ�����

SET @sql='SELECT @PageCount=CEILING((COUNT(*)+0.0)/'+CAST(@PageSize AS nvarchar)+'),@RecordCount=COUNT(*) FROM '+@TableName+@where
EXEC sp_executesql @sql,N'@PageCount int OUTPUT,@RecordCount int OUTPUT',@PageCount OUTPUT,@RecordCount OUTPUT

DECLARE @Start INT
DECLARE @End INT
SELECT @Start = (@PageIndex-1)*@PageSize,@End = @PageIndex*@PageSize;
 
SET @sql='
WITH TMPWITH AS (SELECT '+@ColumnList+', ROW_NUMBER() OVER (ORDER BY '+@OrderBy+') AS RowNumber
FROM '+@TableName+@where+') SELECT '+@ColumnList+' FROM TMPWITH
WHERE RowNumber > '+CAST(@Start AS nvarchar)+' AND RowNumber <= '+CAST(@End AS nvarchar)+' ORDER BY '+@OrderBy
--print @sql
EXEC(@sql)


