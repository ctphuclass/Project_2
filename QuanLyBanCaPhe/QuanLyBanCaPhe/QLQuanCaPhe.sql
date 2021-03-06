USE [master]
GO
/****** Object:  Database [QL_Cafe]    Script Date: 12/15/2017 11:58:11 ******/
CREATE DATABASE [QL_Cafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_Cafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_Cafe.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_Cafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_Cafe_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_Cafe] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_Cafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_Cafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_Cafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_Cafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_Cafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_Cafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_Cafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_Cafe] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QL_Cafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_Cafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_Cafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_Cafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_Cafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_Cafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_Cafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_Cafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_Cafe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_Cafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_Cafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_Cafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_Cafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_Cafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_Cafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_Cafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_Cafe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_Cafe] SET  MULTI_USER 
GO
ALTER DATABASE [QL_Cafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_Cafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_Cafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_Cafe] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QL_Cafe]
GO
/****** Object:  StoredProcedure [dbo].[proc_AddNV]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_AddNV]
	@MaNV char(10), @TenNV nvarchar(50), @GT char(10),@DiaChi nvarchar(50),
	@SDT char(15), @Email char(50), @Ngay_Sinh datetime, @Chuc_Vu nvarchar(50),
	@NVL datetime, @Luong int
As
Begin
	Insert into Nhan_Vien(Ma_NV,Ten_NV,Gioi_Tinh,Dia_Chi,SDT,Email,Ngay_Sinh,Chuc_Vu,Ngay_Vao_Lam,Luong)
	values(@MaNV, @TenNV, @GT,@DiaChi,@SDT,@Email,@Ngay_Sinh,@Chuc_Vu,@NVL,@Luong)
End

GO
/****** Object:  StoredProcedure [dbo].[proc_All]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[proc_All]   @NgayDau datetime, @NgayCuoi datetime
As
Begin
	select Ban.Ten_Ban,Hoa_Don.Ngay_Lap,MENU.Ten_SP,MENU.Loai_SP,Chi_Tiet_Hoa_Don.So_Luong*MENU.Don_Gia As 'ThanhTien'  
from Hoa_Don join Chi_Tiet_Hoa_Don on Hoa_Don.Ma_Hoa_Don = Chi_Tiet_Hoa_Don.Ma_Hoa_Don
						join MENU on Chi_Tiet_Hoa_Don.Ma_SP = MENU.Ma_SP 
						join Ban on Ban.Ma_Ban = Hoa_Don.Ma_Ban
where   (Hoa_Don.Ngay_Lap >= @NgayDau and Hoa_Don.Ngay_Lap <= @NgayCuoi)
End

GO
/****** Object:  StoredProcedure [dbo].[proc_All2]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[proc_All2]   @NgayHT datetime
As
Begin
	select Ban.Ten_Ban,Hoa_Don.Ngay_Lap,MENU.Ten_SP,MENU.Loai_SP,Chi_Tiet_Hoa_Don.So_Luong*MENU.Don_Gia As 'ThanhTien'  
from Hoa_Don join Chi_Tiet_Hoa_Don on Hoa_Don.Ma_Hoa_Don = Chi_Tiet_Hoa_Don.Ma_Hoa_Don
						join MENU on Chi_Tiet_Hoa_Don.Ma_SP = MENU.Ma_SP 
						join Ban on Ban.Ma_Ban = Hoa_Don.Ma_Ban
where   (Hoa_Don.Ngay_Lap = @NgayHT)
End


GO
/****** Object:  StoredProcedure [dbo].[proc_DeleteNV]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_DeleteNV] @MaNV char(10)
As
BEgin
	delete from Nhan_Vien
	where Ma_NV=@MaNV
End

GO
/****** Object:  StoredProcedure [dbo].[proc_DoanhThu]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_DoanhThu] @TenBan nchar(10), @NgayDau datetime, @NgayCuoi datetime
As
Begin
	select Ban.Ten_Ban,Hoa_Don.Ngay_Lap,MENU.Ten_SP,MENU.Loai_SP,Chi_Tiet_Hoa_Don.So_Luong*MENU.Don_Gia As 'ThanhTien'  
from Hoa_Don join Chi_Tiet_Hoa_Don on Hoa_Don.Ma_Hoa_Don = Chi_Tiet_Hoa_Don.Ma_Hoa_Don
						join MENU on Chi_Tiet_Hoa_Don.Ma_SP = MENU.Ma_SP 
						join Ban on Ban.Ma_Ban = Hoa_Don.Ma_Ban
where (Ban.Ten_Ban = @TenBan) and (Hoa_Don.Ngay_Lap >= @NgayDau and Hoa_Don.Ngay_Lap <= @NgayCuoi)
End

GO
/****** Object:  StoredProcedure [dbo].[proc_DoanhThu2]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_DoanhThu2] @TenBan nchar(10), @NgayHT datetime
As
Begin
	select Ban.Ten_Ban,Hoa_Don.Ngay_Lap,MENU.Ten_SP,MENU.Loai_SP,Chi_Tiet_Hoa_Don.So_Luong*MENU.Don_Gia As 'ThanhTien'  
from Hoa_Don join Chi_Tiet_Hoa_Don on Hoa_Don.Ma_Hoa_Don = Chi_Tiet_Hoa_Don.Ma_Hoa_Don
						join MENU on Chi_Tiet_Hoa_Don.Ma_SP = MENU.Ma_SP 
						join Ban on Ban.Ma_Ban = Hoa_Don.Ma_Ban
where (Ban.Ten_Ban = @TenBan) and (Hoa_Don.Ngay_Lap = @NgayHT)
End


GO
/****** Object:  StoredProcedure [dbo].[Proc_HoaDontheoBan]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Proc_HoaDontheoBan]
AS
BEgin
		select * from Ban join Hoa_Don on Ban.Ma_Ban = Hoa_Don.Ma_Ban
				join Chi_Tiet_Hoa_Don on Hoa_Don.Ma_Hoa_Don = Chi_Tiet_Hoa_Don.Ma_Hoa_Don
				join MENU on Chi_Tiet_Hoa_Don.Ma_SP = MENU.Ma_SP	
End

GO
/****** Object:  StoredProcedure [dbo].[proc_InsertCTHD]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_InsertCTHD] @MaHD int , @MaSP char(10),@TenSP nvarchar(50), @SL int 
As
Begin
	declare @IsExitsCTHD int, @DemSL int
	select @IsExitsCTHD = Ma_CTHD,@DemSL = So_Luong from Chi_Tiet_Hoa_Don where  Ma_Hoa_Don = @MaHD and Ma_SP = @MaSP
	if(@IsExitsCTHD > 0)
	begin
			Update Chi_Tiet_Hoa_Don set So_Luong = @SL +  @DemSL where TenSP = @TenSP and Ma_Hoa_Don = @MaHD
	end 
	else
	begin
		Insert into Chi_Tiet_Hoa_Don(Ma_Hoa_Don,Ma_SP,TenSP,So_Luong)
		values (@MaHD,@MaSP,@TenSP,@SL)
	end
End

GO
/****** Object:  StoredProcedure [dbo].[proc_InsertHD]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[proc_InsertHD] @Ma_Ban char(10)
As
Begin
	Insert into Hoa_Don(Ma_Ban, Ngay_Lap, Tinh_Trang)
	Values(@Ma_Ban,GETDATE(),'C')
End

GO
/****** Object:  StoredProcedure [dbo].[proc_LoadNV]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_LoadNV]
As
Begin
	Select * from Nhan_Vien
End

GO
/****** Object:  StoredProcedure [dbo].[proc_Search]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_Search]  @TenNV nvarchar(50) 
AS
BEgin
	
	--if(@TenNV is null)
	--	select * from Nhan_Vien where Ma_NV like @Mannv
	--else
		if not exists (select * from Nhan_Vien where Ten_NV like @TenNV)
		Select * from Nhan_Vien where Ma_NV like @TenNV
		else
		select * from Nhan_Vien where Ten_NV like @TenNV
End

GO
/****** Object:  StoredProcedure [dbo].[proc_TongTien_All]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[proc_TongTien_All]  @NgayDau datetime, @NgayCuoi datetime
As
Begin
	select sum(Chi_Tiet_Hoa_Don.So_Luong*MENU.Don_Gia) As 'TongTien'  
from Hoa_Don join Chi_Tiet_Hoa_Don on Hoa_Don.Ma_Hoa_Don = Chi_Tiet_Hoa_Don.Ma_Hoa_Don
						join MENU on Chi_Tiet_Hoa_Don.Ma_SP = MENU.Ma_SP 
						join Ban on Ban.Ma_Ban = Hoa_Don.Ma_Ban
where  (Hoa_Don.Ngay_Lap >= @NgayDau and Hoa_Don.Ngay_Lap <= @NgayCuoi)
End
GO
/****** Object:  StoredProcedure [dbo].[proc_TongTien_All2]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[proc_TongTien_All2]  @NgayHT datetime
As
Begin
	select sum(Chi_Tiet_Hoa_Don.So_Luong*MENU.Don_Gia) As 'TongTien'  
from Hoa_Don join Chi_Tiet_Hoa_Don on Hoa_Don.Ma_Hoa_Don = Chi_Tiet_Hoa_Don.Ma_Hoa_Don
						join MENU on Chi_Tiet_Hoa_Don.Ma_SP = MENU.Ma_SP 
						join Ban on Ban.Ma_Ban = Hoa_Don.Ma_Ban
where  (Hoa_Don.Ngay_Lap = @NgayHT)
End

GO
/****** Object:  StoredProcedure [dbo].[proc_TongTienBan]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[proc_TongTienBan] @TenBan nchar(10), @NgayDau datetime, @NgayCuoi datetime
As
Begin
	select sum(Chi_Tiet_Hoa_Don.So_Luong*MENU.Don_Gia) As 'TongTien'  
from Hoa_Don join Chi_Tiet_Hoa_Don on Hoa_Don.Ma_Hoa_Don = Chi_Tiet_Hoa_Don.Ma_Hoa_Don
						join MENU on Chi_Tiet_Hoa_Don.Ma_SP = MENU.Ma_SP 
						join Ban on Ban.Ma_Ban = Hoa_Don.Ma_Ban
where (Ban.Ten_Ban = @TenBan) and (Hoa_Don.Ngay_Lap >= @NgayDau and Hoa_Don.Ngay_Lap <= @NgayCuoi)
End

GO
/****** Object:  StoredProcedure [dbo].[proc_TongTienBan2]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[proc_TongTienBan2] @TenBan nchar(10), @NgayHT datetime
As
Begin
	select sum(Chi_Tiet_Hoa_Don.So_Luong*MENU.Don_Gia) As 'TongTien'  
from Hoa_Don join Chi_Tiet_Hoa_Don on Hoa_Don.Ma_Hoa_Don = Chi_Tiet_Hoa_Don.Ma_Hoa_Don
						join MENU on Chi_Tiet_Hoa_Don.Ma_SP = MENU.Ma_SP 
						join Ban on Ban.Ma_Ban = Hoa_Don.Ma_Ban
where (Ban.Ten_Ban = @TenBan) and (Hoa_Don.Ngay_Lap = @NgayHT)
End


GO
/****** Object:  StoredProcedure [dbo].[proc_UpdateBan]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[proc_UpdateBan]
	@Ma_Ban char(10),@Ten_Ban nchar(10),@Ma_KV nvarchar(50),@Tinh_Trang char(10),@So_TT int,
	 @Message nvarchar(50) output, @resutsID int output
As
BEgin
	declare @sl int
	select @sl=count(*) from Ban where Ma_Ban = @Ma_Ban
	if(@sl >= 1)
	begin
	Update Ban
	set  Ma_Ban=@Ma_Ban, Ten_Ban=@Ten_Ban, Ma_KV=@Ma_KV, Tinh_Trang=@Tinh_Trang, So_TT=@So_TT
	where Ma_Ban =@Ma_Ban
	Select @Message = N'Sữa Thành Công', @resutsID = 1 
	return
	end
	else
	select @Message = N'Mã Bàn Không Tồn Tại', @resutsID = -1 
	return	
End

GO
/****** Object:  StoredProcedure [dbo].[proc_UpdateMENU]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[proc_UpdateMENU]
	@Ma_SP char(10),@Ten_SP nvarchar(50),@Loai_SP nvarchar(50),@DVT nvarchar(50),@Don_Gia int,
	 @Message nvarchar(50) output, @resutsID int output
As
BEgin
	declare @sl int
	select @sl=count(*) from MENU where Ma_SP = @Ma_SP
	if(@sl >= 1)
	begin
	Update MENU
	set  Ma_SP=@Ma_SP, Ten_SP=@Ten_SP, Loai_SP=@Loai_SP, DVT=@DVT, Don_Gia=@Don_Gia
	where Ma_SP =@Ma_SP
	Select @Message = N'Sữa Thành Công', @resutsID = 1 
	return
	end
	else
	select @Message = N'Sản Phẩm Không Tồn Tại', @resutsID = -1 
	return	
End

GO
/****** Object:  StoredProcedure [dbo].[proc_UpdateNV]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_UpdateNV]
	@MaNV char(10), @TenNV nvarchar(50), @GT char(10),@DiaChi nvarchar(50),
	@SDT char(15), @Email char(50), @Ngay_Sinh datetime, @Chuc_Vu nvarchar(50),
	@NVL datetime, @Luong int, @Message nvarchar(50) output, @resutsID int output
As
BEgin
	declare @sl int
	select @sl=count(*) from Nhan_Vien where Ma_NV = @MaNV
	if(@sl >= 1)
	begin
	Update Nhan_Vien
	set  Ten_NV=@TenNV,Gioi_Tinh=@GT,Dia_Chi=@DiaChi,SDT=@SDT,Email=@Email,Ngay_Sinh=@Ngay_Sinh,Chuc_Vu=@Chuc_Vu,Ngay_Vao_Lam=@NVL,Luong=@Luong
	where Ma_NV =@MaNV
	Select @Message = N'Sữa Thành Công', @resutsID = 1 
	return
	end
	else
	select @Message = N'Mã Nhân Viên Không Tồn Tại', @resutsID = -1 
	return	
End
GO
/****** Object:  StoredProcedure [dbo].[proc_XoaMENU]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[proc_XoaMENU]
@psMaSP varchar(50),
@pResultCode int output,
@pResultMessage nvarchar(50) output
AS
BEGIN	
	IF Exists(Select Ma_SP  from MENU where Ma_SP = @psMaSP)
	--Neu Ton Tai
	BEGIN	
		--Thong Bao Thanh Cong
		SELECT @pResultCode = 1, @pResultMessage = 'Đã Xóa' from MENU where Ma_SP = @psMaSP
		--Xoa User
		DELETE from MENU where Ma_SP = @psMaSP
		RETURN
	END
	--Khong Ton Tai
	ELSE
	BEGIN
		SELECT @pResultCode = -1 , @pResultMessage = N'Sản Phẩm Không Tồn Tại'
		RETURN
	END
END





GO
/****** Object:  StoredProcedure [dbo].[usp_USER_ChangePassword]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[usp_USER_ChangePassword]
@psUsername varchar(50),
@psPassword varchar(50),
@psChangePasword varchar(50),
@pResultCode int output,
@pResultMessage varchar(50) output
AS
BEGIN
	--Chuyen Password Ma Hoa
	DECLARE @lPasswordHash varchar(32)
	DECLARE @lChangePasswordHash varchar(32)
	SET @lPasswordHash = HASHBYTES('SHA2_256', @psPassword)
	SET @lChangePasswordHash = HASHBYTES('SHA2_256', @psChangePasword)
	--KT User, Pass
	IF Exists(Select ID from [User] where UserName = @psUsername and PassWord = @lPasswordHash)
	--Neu Ton Tai
	BEGIN
		--Doi MK
		Update [User] SET PassWord = @lChangePasswordHash WHERE UserName = @psUsername 
		SELECT @pResultCode = ID, @pResultMessage = 'CHANGEPASSWORDOK' from [User] where UserName = @psUsername and PassWord = @lChangePasswordHash
		RETURN
	END
	--Khong Ton Tai
	ELSE
	BEGIN
		SELECT @pResultCode = -1 , @pResultMessage = 'CHANGEPASSWORDFAILED' 
		RETURN
	END
END


GO
/****** Object:  StoredProcedure [dbo].[usp_USER_CheckUser]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_USER_CheckUser]
@psUsername varchar(50),
@psPassword varchar(50)
AS
BEGIN

	DECLARE @lPasswordHash varchar(32)
	SET @lPasswordHash = HASHBYTES('SHA2_256', @psPassword)
	IF Not Exists(Select ID from [User] where UserName = @psUsername and PassWord = @lPasswordHash)
	BEGIN
		SELECT printf = 'LOGINFAILED'
	END
	ELSE
	BEGIN
		SELECT [User].*,Nhan_Vien.Chuc_Vu  from [User] join Nhan_Vien  on [User].Username = Nhan_Vien.Ma_NV
		where UserName = @psUsername and PassWord = @lPasswordHash
		
	END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_USER_CreateUser]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[usp_USER_CreateUser]
	@psUsername varchar(50)
	,@psPassword varchar(255)
	,@pResultCode int output
	,@pResultMessage varchar(50) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @lPasswordHash varchar(32)

	IF Exists(Select ID from [User] WHERE Username = @psUsername)
	BEGIN
		SELECT @pResultCode = -1, @pResultMessage = 'USEREXISTED'
		RETURN
	END

	SET @lPasswordHash = HASHBYTES('SHA2_256', @psPassword)

	INSERT INTO [User](Username, Password, IsDisable) Values(@psUsername, @lPasswordHash, 0)
	
	SELECT @pResultCode = SCOPE_IDENTITY(), @pResultMessage = 'USERCREATEDOK'
	RETURN
END


GO
/****** Object:  StoredProcedure [dbo].[usp_USER_DeleteUser]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[usp_USER_DeleteUser]
@psMaNV varchar(50),
@pResultCode int output,
@pResultMessage varchar(50) output
AS
BEGIN	
	IF Exists(Select Ma_NV  from Nhan_Vien where Ma_NV = @psMaNV)
	--Neu Ton Tai
	BEGIN	
		--Thong Bao Thanh Cong
		SELECT @pResultCode = 1, @pResultMessage = 'DELETEUSEROK' from Nhan_Vien where Ma_NV = @psMaNV
		--Xoa User
		DELETE from Nhan_Vien where Ma_NV = @psMaNV
		RETURN
	END
	--Khong Ton Tai
	ELSE
	BEGIN
		SELECT @pResultCode = -1 , @pResultMessage = N'Mã Nhân Viên Không Có'
		RETURN
	END
END





GO
/****** Object:  StoredProcedure [dbo].[XoaBan]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[XoaBan]
@psMaBan char(10),
@pResultCode int output,
@pResultMessage varchar(50) output
AS
BEGIN	
	--IF Exists(Select Ma_Ban from Ban where Ma_Ban = @psMaBan)
	--Neu Ton Tai
	declare @sl int
	select @sl=count(*) from Ban where Ma_Ban = @psMaBan
	if(@sl >= 1)
	BEGIN	
		--Thong Bao Thanh Cong
		SELECT @pResultCode = 1, @pResultMessage = N'Đã Xóa' from Ban where Ma_Ban = @psMaBan
		--Xoa User
		DELETE from Ban where Ma_Ban = @psMaBan
		RETURN
	END
	--Khong Ton Tai
	ELSE
	BEGIN
		SELECT @pResultCode = -1 , @pResultMessage = N'Bàn Này Không Có'
		RETURN
	END
END




GO
/****** Object:  Table [dbo].[Ban]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ban](
	[Ma_Ban] [char](10) NOT NULL,
	[Ten_Ban] [nchar](10) NULL,
	[Ma_KV] [nvarchar](50) NULL,
	[Tinh_Trang] [char](10) NULL,
	[So_TT] [int] NULL,
 CONSTRAINT [PK_Ban] PRIMARY KEY CLUSTERED 
(
	[Ma_Ban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Chi_Tiet_Hoa_Don]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Chi_Tiet_Hoa_Don](
	[Ma_CTHD] [int] IDENTITY(1,1) NOT NULL,
	[Ma_Hoa_Don] [int] NOT NULL,
	[Ma_SP] [char](10) NULL,
	[So_Luong] [int] NULL,
	[TenSP] [nvarchar](50) NULL,
 CONSTRAINT [PK_Chi_Tiet_Hoa_Don] PRIMARY KEY CLUSTERED 
(
	[Ma_CTHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Dang_Nhap_LogIn]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dang_Nhap_LogIn](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Ma_NV] [char](10) NULL,
	[Ten_Dang_Nhap] [char](50) NULL,
	[Mat_Khau] [nchar](20) NULL,
	[Quyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_Dang_Nhap_LogIn] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hoa_Don]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hoa_Don](
	[Ma_Hoa_Don] [int] IDENTITY(1,1) NOT NULL,
	[Ma_Ban] [char](10) NULL,
	[Ngay_Lap] [date] NULL,
	[Tinh_Trang] [char](10) NULL,
 CONSTRAINT [PK_Hoa_Don] PRIMARY KEY CLUSTERED 
(
	[Ma_Hoa_Don] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Khu_Vuc]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Khu_Vuc](
	[Ma_KV] [nvarchar](50) NOT NULL,
	[Ten_KV] [nvarchar](50) NULL,
	[Ma_NV] [char](10) NULL,
 CONSTRAINT [PK_Khu_Vuc] PRIMARY KEY CLUSTERED 
(
	[Ma_KV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MENU]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MENU](
	[Ma_SP] [char](10) NOT NULL,
	[Ten_SP] [nvarchar](50) NULL,
	[Loai_SP] [nvarchar](50) NULL,
	[DVT] [nvarchar](50) NULL,
	[Don_Gia] [int] NULL,
 CONSTRAINT [PK_MENU] PRIMARY KEY CLUSTERED 
(
	[Ma_SP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Nhan_Vien]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nhan_Vien](
	[Ma_NV] [char](10) NOT NULL,
	[Ten_NV] [nvarchar](50) NULL,
	[Gioi_Tinh] [char](10) NULL,
	[Dia_Chi] [nvarchar](200) NULL,
	[SDT] [char](15) NULL,
	[Email] [char](50) NULL,
	[Ngay_Sinh] [datetime] NULL,
	[Chuc_Vu] [nvarchar](50) NULL,
	[Ngay_Vao_Lam] [datetime] NULL,
	[Luong] [int] NULL,
 CONSTRAINT [PK_Nhan_Vien] PRIMARY KEY CLUSTERED 
(
	[Ma_NV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [char](10) NULL,
	[Password] [nvarchar](255) NULL,
	[IsDisable] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B1        ', N'Ban So 1  ', N'1', N'On        ', 2)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B2        ', N'Ban So 2  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B3        ', N'Ban So 3  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B4        ', N'Ban so 4  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B5        ', N'Ban so 5  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B6        ', N'Ban so 6  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B7        ', N'Ban So 7  ', N'1', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B8        ', N'Ban So 8  ', N'1', N'Off       ', 1)
SET IDENTITY_INSERT [dbo].[Chi_Tiet_Hoa_Don] ON 

INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (499, 98, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (500, 99, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (501, 100, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (502, 101, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (503, 102, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (504, 103, N'SP1       ', 4, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (505, 104, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (506, 105, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (507, 106, N'SP2       ', 1, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (508, 107, N'SP2       ', 3, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (509, 107, N'SP3       ', 2, N'My Cay')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (510, 107, N'SP1       ', 3, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (511, 108, N'SP2       ', 1, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (512, 109, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (513, 110, N'SP1       ', 4, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (514, 110, N'SP2       ', 1, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (515, 110, N'SP3       ', 1, N'My Cay')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (516, 111, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (517, 111, N'SP2       ', 1, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (519, 113, N'SP2       ', 1, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (520, 114, N'SP3       ', 1, N'My Cay')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (521, 115, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (522, 116, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (523, 117, N'SP2       ', 1, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (524, 117, N'SP3       ', 2, N'My Cay')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (525, 118, N'SP3       ', 1, N'My Cay')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (526, 119, N'SP3       ', 1, N'My Cay')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (527, 120, N'SP1       ', 2, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (528, 120, N'SP2       ', 3, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (529, 121, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (530, 122, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (531, 122, N'SP3       ', 1, N'My Cay')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (532, 123, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (533, 124, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (534, 125, N'SP1       ', 2, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (535, 125, N'SP2       ', 3, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (536, 126, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (537, 127, N'SP1       ', 3, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (538, 128, N'SP2       ', 2, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (539, 128, N'SP1       ', 1, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (540, 128, N'SP3       ', 1, N'My Cay')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (541, 129, N'SP1       ', 3, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (542, 129, N'SP2       ', 1, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (543, 129, N'SP3       ', 1, N'My Cay')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (544, 130, N'SP1       ', 2, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (545, 130, N'SP2       ', 1, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (546, 130, N'SP3       ', 1, N'My Cay')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (547, 131, N'SP1       ', 2, N'Sting')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (548, 132, N'SP2       ', 1, N'BimBim')
INSERT [dbo].[Chi_Tiet_Hoa_Don] ([Ma_CTHD], [Ma_Hoa_Don], [Ma_SP], [So_Luong], [TenSP]) VALUES (549, 133, N'SP1       ', 1, N'Sting')
SET IDENTITY_INSERT [dbo].[Chi_Tiet_Hoa_Don] OFF
SET IDENTITY_INSERT [dbo].[Dang_Nhap_LogIn] ON 

INSERT [dbo].[Dang_Nhap_LogIn] ([UserID], [Ma_NV], [Ten_Dang_Nhap], [Mat_Khau], [Quyen]) VALUES (2, N'0001      ', N'admin                                             ', N'admin               ', N'QuanLy')
SET IDENTITY_INSERT [dbo].[Dang_Nhap_LogIn] OFF
SET IDENTITY_INSERT [dbo].[Hoa_Don] ON 

INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (98, N'B1        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (99, N'B6        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (100, N'B1        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (101, N'B2        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (102, N'B2        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (103, N'B2        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (104, N'B4        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (105, N'B2        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (106, N'B2        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (107, N'B2        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (108, N'B4        ', CAST(0x913D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (109, N'B3        ', CAST(0x933D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (110, N'B1        ', CAST(0x953D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (111, N'B2        ', CAST(0x953D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (113, N'B1        ', CAST(0x953D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (114, N'B2        ', CAST(0x953D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (115, N'B1        ', CAST(0x963D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (116, N'B4        ', CAST(0x963D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (117, N'B7        ', CAST(0x963D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (118, N'B7        ', CAST(0x963D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (119, N'B5        ', CAST(0x963D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (120, N'B1        ', CAST(0x973D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (121, N'B1        ', CAST(0x973D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (122, N'B1        ', CAST(0x973D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (123, N'B1        ', CAST(0x973D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (124, N'B1        ', CAST(0x973D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (125, N'B1        ', CAST(0x983D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (126, N'B1        ', CAST(0x983D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (127, N'B2        ', CAST(0x983D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (128, N'B3        ', CAST(0x983D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (129, N'B1        ', CAST(0x983D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (130, N'B1        ', CAST(0x9B3D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (131, N'B1        ', CAST(0x9B3D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (132, N'B4        ', CAST(0x9B3D0B00 AS Date), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (133, N'B1        ', CAST(0xA23D0B00 AS Date), N'C         ')
SET IDENTITY_INSERT [dbo].[Hoa_Don] OFF
INSERT [dbo].[Khu_Vuc] ([Ma_KV], [Ten_KV], [Ma_NV]) VALUES (N'1         ', N'Chinh', NULL)
INSERT [dbo].[Khu_Vuc] ([Ma_KV], [Ten_KV], [Ma_NV]) VALUES (N'2', N'Tang 2', NULL)
INSERT [dbo].[Khu_Vuc] ([Ma_KV], [Ten_KV], [Ma_NV]) VALUES (N'3', N'Tang 3', NULL)
INSERT [dbo].[MENU] ([Ma_SP], [Ten_SP], [Loai_SP], [DVT], [Don_Gia]) VALUES (N'SP1       ', N'Sting', N'Đồ Uống', N'Chai', 15000)
INSERT [dbo].[MENU] ([Ma_SP], [Ten_SP], [Loai_SP], [DVT], [Don_Gia]) VALUES (N'SP2       ', N'BimBim', N'Dịch Vụ', N'Bịch', 6000)
INSERT [dbo].[MENU] ([Ma_SP], [Ten_SP], [Loai_SP], [DVT], [Don_Gia]) VALUES (N'SP3       ', N'My Cay', N'Thức Ăn', N'Suất', 45000)
INSERT [dbo].[MENU] ([Ma_SP], [Ten_SP], [Loai_SP], [DVT], [Don_Gia]) VALUES (N'SP4       ', N'My Cay', N'Thức Ăn', N'Suất', 5000)
INSERT [dbo].[Nhan_Vien] ([Ma_NV], [Ten_NV], [Gioi_Tinh], [Dia_Chi], [SDT], [Email], [Ngay_Sinh], [Chuc_Vu], [Ngay_Vao_Lam], [Luong]) VALUES (N'0001      ', N'abc', N'nu        ', N'123', N'ddsa           ', NULL, CAST(0x0000A77100000000 AS DateTime), N'NhanVien', CAST(0x0000A77100000000 AS DateTime), 12)
INSERT [dbo].[Nhan_Vien] ([Ma_NV], [Ten_NV], [Gioi_Tinh], [Dia_Chi], [SDT], [Email], [Ngay_Sinh], [Chuc_Vu], [Ngay_Vao_Lam], [Luong]) VALUES (N'0002      ', N'Nguyen Thanh Dat', N'Nam       ', N'Tp HCm', N'09750000000    ', N'123@gamil.com                                     ', CAST(0x00008C6200000000 AS DateTime), N'NhanVien', CAST(0x0000A82900000000 AS DateTime), 20)
INSERT [dbo].[Nhan_Vien] ([Ma_NV], [Ten_NV], [Gioi_Tinh], [Dia_Chi], [SDT], [Email], [Ngay_Sinh], [Chuc_Vu], [Ngay_Vao_Lam], [Luong]) VALUES (N'0003      ', N'Le Van ABC', N'Nu        ', N'Quang Ngai', N'234324234      ', N'456@gmail.com                                     ', CAST(0x000083A800000000 AS DateTime), N'NhanVien', CAST(0x0000A83D00000000 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Username], [Password], [IsDisable]) VALUES (1, N'admin     ', N'ŒivåµA½é½Mîß±g©ÈsüK¸¨o*´H©', 0)
INSERT [dbo].[User] ([ID], [Username], [Password], [IsDisable]) VALUES (4, N'0001      ', N'ˆ‹¤;ƒÈx•ö!Ÿ†@ù{ÜŽó/ÛàWÈõåm2', 0)
INSERT [dbo].[User] ([ID], [Username], [Password], [IsDisable]) VALUES (5, N'0003      ', N'k†²sÿ4üák€NÿZ?WG­¤ê¢/IÀRÝ·‡[K', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Ban]  WITH CHECK ADD  CONSTRAINT [FK_Ban_Khu_Vuc] FOREIGN KEY([Ma_KV])
REFERENCES [dbo].[Khu_Vuc] ([Ma_KV])
GO
ALTER TABLE [dbo].[Ban] CHECK CONSTRAINT [FK_Ban_Khu_Vuc]
GO
ALTER TABLE [dbo].[Chi_Tiet_Hoa_Don]  WITH CHECK ADD  CONSTRAINT [FK_Chi_Tiet_Hoa_Don_Hoa_Don] FOREIGN KEY([Ma_Hoa_Don])
REFERENCES [dbo].[Hoa_Don] ([Ma_Hoa_Don])
GO
ALTER TABLE [dbo].[Chi_Tiet_Hoa_Don] CHECK CONSTRAINT [FK_Chi_Tiet_Hoa_Don_Hoa_Don]
GO
ALTER TABLE [dbo].[Chi_Tiet_Hoa_Don]  WITH CHECK ADD  CONSTRAINT [FK_Chi_Tiet_Hoa_Don_MENU] FOREIGN KEY([Ma_SP])
REFERENCES [dbo].[MENU] ([Ma_SP])
GO
ALTER TABLE [dbo].[Chi_Tiet_Hoa_Don] CHECK CONSTRAINT [FK_Chi_Tiet_Hoa_Don_MENU]
GO
ALTER TABLE [dbo].[Dang_Nhap_LogIn]  WITH CHECK ADD  CONSTRAINT [FK_Dang_Nhap_LogIn_Nhan_Vien] FOREIGN KEY([Ma_NV])
REFERENCES [dbo].[Nhan_Vien] ([Ma_NV])
GO
ALTER TABLE [dbo].[Dang_Nhap_LogIn] CHECK CONSTRAINT [FK_Dang_Nhap_LogIn_Nhan_Vien]
GO
ALTER TABLE [dbo].[Hoa_Don]  WITH CHECK ADD  CONSTRAINT [FK_Hoa_Don_Ban] FOREIGN KEY([Ma_Ban])
REFERENCES [dbo].[Ban] ([Ma_Ban])
GO
ALTER TABLE [dbo].[Hoa_Don] CHECK CONSTRAINT [FK_Hoa_Don_Ban]
GO
ALTER TABLE [dbo].[Khu_Vuc]  WITH CHECK ADD  CONSTRAINT [FK_Khu_Vuc_Nhan_Vien] FOREIGN KEY([Ma_NV])
REFERENCES [dbo].[Nhan_Vien] ([Ma_NV])
GO
ALTER TABLE [dbo].[Khu_Vuc] CHECK CONSTRAINT [FK_Khu_Vuc_Nhan_Vien]
GO
ALTER TABLE [dbo].[User]  WITH NOCHECK ADD  CONSTRAINT [FK_User_Nhan_Vien] FOREIGN KEY([Username])
REFERENCES [dbo].[Nhan_Vien] ([Ma_NV])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Nhan_Vien]
GO
/****** Object:  Trigger [dbo].[trig_ThayDoiTinhTrangBanOn]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trig_ThayDoiTinhTrangBanOn] on [dbo].[Chi_Tiet_Hoa_Don] for insert, update
As
Begin
	declare @MaHD int, @MaBan char(10)
	Select @MaHD= Ma_Hoa_Don from inserted
	select @MaBan=Ma_Ban from Hoa_Don where Ma_Hoa_Don=@MaHD and Tinh_Trang='C'
	update Ban set Tinh_Trang = 'On', So_TT = 2 where Ma_Ban = @MaBan
End

GO
/****** Object:  Trigger [dbo].[trig_ThayDoiTinhTrangBanOff]    Script Date: 12/15/2017 11:58:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trig_ThayDoiTinhTrangBanOff] on [dbo].[Hoa_Don] for update
As
BEgin
	declare @MaHD int , @MaBan char(10), @SLHD int = 0
	select @MaHD=Ma_Hoa_Don from inserted
	Select @MaBan=Ma_Ban from Hoa_Don where @MaHD=Ma_Hoa_Don
	select @SLHD = COUNT(Ma_Hoa_Don) from Hoa_Don where Ma_Ban=@MaBan and Tinh_Trang = 'C'
	if(@SLHD = 0)
		update Ban set So_TT = 1, Tinh_Trang ='Off' where Ma_Ban=@MaBan
End

GO
USE [master]
GO
ALTER DATABASE [QL_Cafe] SET  READ_WRITE 
GO
