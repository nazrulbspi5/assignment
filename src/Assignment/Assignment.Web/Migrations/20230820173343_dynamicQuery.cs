using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Web.Migrations
{
    /// <inheritdoc />
    public partial class dynamicQuery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE OR ALTER FUNCTION [dbo].[func_getEmployee]
						(
							@Id int =NULL
						)
						Returns @data TABLE (
							Id int,
							Name varchar(50),
							Postion varchar(50),
							SalaryAmount decimal(10,2),
							JoiningDate datetime
						)
						AS
						BEGIN
						Declare 
								@manager_Id int,
								@root_ManagerId int
						
						
						
						IF (@id is not  null)
						BEGIN
							INSERT INTO @data
							SELECT Id,Name,Postion,SalaryAmount,JoiningDate FROM Employees WHERE Id =@Id
							SELECT @manager_Id = ManagerId FROM Employees WHERE Id =@Id
						END
						ELSE
						BEGIN
							INSERT INTO @data
							SELECT Id,Name,Postion,SalaryAmount,JoiningDate FROM Employees
							
						END
						
						
						WHILE (@manager_Id is not null)  
						BEGIN  
							
							INSERT INTO @data
							SELECT Id,Name,Postion,SalaryAmount,JoiningDate FROM Employees WHERE ID =@manager_Id
							SELECT @manager_Id = ManagerId FROM Employees WHERE Id =@manager_Id
							
						END
						RETURN
						END
--
				GO
--
CREATE OR ALTER PROCEDURE [dbo].[proc_GetEmployees]
						@PageIndex int,
						@PageSize int,
						@SearchText nvarchar(250) = '%',
						@OrderBy nvarchar(50),
						@Id int = null,
						@Total int output,
						@TotalDisplay int output

						AS
						BEGIN
							Declare @sql nvarchar(4000);
							Declare @totalSql nvarchar(4000)
							Declare @countSql nvarchar(4000);
							Declare @paramList nvarchar(MAX);
							Declare @totalparamList nvarchar(MAX);
							Declare @countparamList nvarchar(MAX);

							SET NOCOUNT ON;
	
							SET @totalSql = 'SELECT @Total = COUNT(*) FROM Employees'
							SET @countsql = 'SELECT @TotalDisplay = COUNT(*) FROM Employees';
							
							SET @sql ='SELECT  Id,Name,Postion,SalaryAmount,JoiningDate FROM func_getEmployee(@xId) WHERE 1=1'
							
							--IF @Id IS NOT NULL
							--	SET @sql = @sql + ' AND ID= @xId';

							SET @sql = @sql + ' ORDER BY '+ @OrderBy +' OFFSET @PageSize * (@PageIndex - 1) 
								ROWS FETCH NEXT @PageSize ROWS ONLY';

							SELECT @totalparamlist ='@xId int,
													@Total int output';

							exec sp_executesql @totalsql, @totalparamlist,
								@Id,
								@Total = @Total output;

							SELECT @countparamlist ='@xId int,
														@xSearchText nvarchar(250),
														@TotalDisplay int output';

							exec sp_executesql @countsql, @countparamlist,
								@Id,
								@SearchText,
								@TotalDisplay = @TotalDisplay output;

							SELECT @paramlist = '@xId int,
								@xSearchText nvarchar(250),
								@PageIndex int, 
								@PageSize int';

							exec sp_executesql @sql, @paramlist,
								@Id,
								@SearchText,
								@PageIndex,
								@PageSize;

							print @sql;
							print @totalSql;
							print @countSql;

				END
				--
				Go
				--";
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP FUNCTION [dbo].[func_getEmployee]
					--
					GO
					--	
				DROP FUNCTION [dbo].[PROCEDURE]
					";
            migrationBuilder.Sql(sql);
        }
    }
}
