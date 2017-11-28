USE [master]
GO
/****** Object:  Database [QL_Cafe]    Script Date: 11/28/2017 2:38:15 PM ******/
CREATE DATABASE [QL_Cafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_Cafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_Cafe.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_Cafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_Cafe_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
/****** Object:  StoredProcedure [dbo].[proc_AddNV]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_DeleteNV]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_DoanhThu]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Proc_HoaDontheoBan]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_InsertCTHD]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_InsertHD]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_LoadNV]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_Search]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_TongTienBan]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_UpdateNV]    Script Date: 11/28/2017 2:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_UpdateNV]
	@MaNV char(10), @TenNV nvarchar(50), @GT char(10),@DiaChi nvarchar(50),
	@SDT char(15), @Email char(50), @Ngay_Sinh datetime, @Chuc_Vu nvarchar(50),
	@NVL datetime, @Luong int
As
BEgin
	Update Nhan_Vien
	set  Ten_NV=@TenNV,Gioi_Tinh=@GT,Dia_Chi=@DiaChi,SDT=@SDT,Email=@Email,Ngay_Sinh=@Ngay_Sinh,Chuc_Vu=@Chuc_Vu,Ngay_Vao_Lam=@NVL,Luong=@Luong
	where Ma_NV =@MaNV
End
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  Table [dbo].[Chi_Tiet_Hoa_Don]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  Table [dbo].[Dang_Nhap_LogIn]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  Table [dbo].[Hoa_Don]    Script Date: 11/28/2017 2:38:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hoa_Don](
	[Ma_Hoa_Don] [int] IDENTITY(1,1) NOT NULL,
	[Ma_Ban] [char](10) NULL,
	[Ngay_Lap] [datetime] NULL,
	[Tinh_Trang] [char](10) NULL,
 CONSTRAINT [PK_Hoa_Don] PRIMARY KEY CLUSTERED 
(
	[Ma_Hoa_Don] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Khu_Vuc]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  Table [dbo].[MENU]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  Table [dbo].[Nhan_Vien]    Script Date: 11/28/2017 2:38:15 PM ******/
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
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B1        ', N'Ban So 1  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B2        ', N'Ban So 2  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B3        ', N'Ban So 3  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B4        ', N'Ban so 4  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B5        ', N'Ban so 5  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B6        ', N'Ban so 6  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B7        ', N'Ban so 7  ', N'1         ', N'Off       ', 1)
INSERT [dbo].[Ban] ([Ma_Ban], [Ten_Ban], [Ma_KV], [Tinh_Trang], [So_TT]) VALUES (N'B8        ', N'Ban so 8  ', N'1         ', N'Off       ', 1)
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
SET IDENTITY_INSERT [dbo].[Chi_Tiet_Hoa_Don] OFF
SET IDENTITY_INSERT [dbo].[Dang_Nhap_LogIn] ON 

INSERT [dbo].[Dang_Nhap_LogIn] ([UserID], [Ma_NV], [Ten_Dang_Nhap], [Mat_Khau], [Quyen]) VALUES (2, N'0001      ', N'admin                                             ', N'admin               ', N'QuanLy')
SET IDENTITY_INSERT [dbo].[Dang_Nhap_LogIn] OFF
SET IDENTITY_INSERT [dbo].[Hoa_Don] ON 

INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (98, N'B1        ', CAST(N'2017-11-25 09:57:28.337' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (99, N'B6        ', CAST(N'2017-11-25 09:57:48.683' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (100, N'B1        ', CAST(N'2017-11-25 09:58:46.603' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (101, N'B2        ', CAST(N'2017-11-25 10:10:20.733' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (102, N'B2        ', CAST(N'2017-11-25 10:10:47.470' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (103, N'B2        ', CAST(N'2017-11-25 10:17:51.050' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (104, N'B4        ', CAST(N'2017-11-25 10:18:03.853' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (105, N'B2        ', CAST(N'2017-11-25 10:27:52.263' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (106, N'B2        ', CAST(N'2017-11-25 11:38:02.297' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (107, N'B2        ', CAST(N'2017-11-25 11:38:15.460' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (108, N'B4        ', CAST(N'2017-11-25 11:40:15.800' AS DateTime), N'R         ')
INSERT [dbo].[Hoa_Don] ([Ma_Hoa_Don], [Ma_Ban], [Ngay_Lap], [Tinh_Trang]) VALUES (109, N'B3        ', CAST(N'2017-11-27 08:01:38.920' AS DateTime), N'R         ')
SET IDENTITY_INSERT [dbo].[Hoa_Don] OFF
INSERT [dbo].[Khu_Vuc] ([Ma_KV], [Ten_KV], [Ma_NV]) VALUES (N'1         ', N'Chinh', NULL)
INSERT [dbo].[MENU] ([Ma_SP], [Ten_SP], [Loai_SP], [DVT], [Don_Gia]) VALUES (N'SP1       ', N'Sting', N'Đồ Uống', N'Chai', 15000)
INSERT [dbo].[MENU] ([Ma_SP], [Ten_SP], [Loai_SP], [DVT], [Don_Gia]) VALUES (N'SP2       ', N'BimBim', N'Dịch Vụ', N'Bịch', 6000)
INSERT [dbo].[MENU] ([Ma_SP], [Ten_SP], [Loai_SP], [DVT], [Don_Gia]) VALUES (N'SP3       ', N'My Cay', N'Thức Ăn', N'Suất', 45000)
INSERT [dbo].[Nhan_Vien] ([Ma_NV], [Ten_NV], [Gioi_Tinh], [Dia_Chi], [SDT], [Email], [Ngay_Sinh], [Chuc_Vu], [Ngay_Vao_Lam], [Luong]) VALUES (N'0001      ', N'Le Van Phap', N'Nam       ', N'Tp HCm', N'01662394876    ', N'lekaku985@gmail.com                               ', CAST(N'1993-02-28 00:00:00.000' AS DateTime), N'Quan Li', CAST(N'2017-11-27 00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Nhan_Vien] ([Ma_NV], [Ten_NV], [Gioi_Tinh], [Dia_Chi], [SDT], [Email], [Ngay_Sinh], [Chuc_Vu], [Ngay_Vao_Lam], [Luong]) VALUES (N'0002      ', N'Nguyen Thanh Dat', N'Nam       ', N'Tp HCm', N'09750000000    ', N'123@gamil.com                                     ', CAST(N'1998-05-25 00:00:00.000' AS DateTime), N'Quan Li', CAST(N'2017-11-12 00:00:00.000' AS DateTime), 20)
INSERT [dbo].[Nhan_Vien] ([Ma_NV], [Ten_NV], [Gioi_Tinh], [Dia_Chi], [SDT], [Email], [Ngay_Sinh], [Chuc_Vu], [Ngay_Vao_Lam], [Luong]) VALUES (N'0003      ', N'Le Van ABC', N'Nu        ', N'Quang Ngai', N'12312345655    ', N'456@gmail.com                                     ', CAST(N'1992-04-12 00:00:00.000' AS DateTime), N'NhanVien', CAST(N'2017-12-02 00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Nhan_Vien] ([Ma_NV], [Ten_NV], [Gioi_Tinh], [Dia_Chi], [SDT], [Email], [Ngay_Sinh], [Chuc_Vu], [Ngay_Vao_Lam], [Luong]) VALUES (N'000333    ', N'Le Van ABC', N'Nu        ', N'Quang Ngai', N'12312345655    ', N'456@gmail.com                                     ', CAST(N'1992-04-12 00:00:00.000' AS DateTime), N'NhanVien', CAST(N'2017-12-02 00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Nhan_Vien] ([Ma_NV], [Ten_NV], [Gioi_Tinh], [Dia_Chi], [SDT], [Email], [Ngay_Sinh], [Chuc_Vu], [Ngay_Vao_Lam], [Luong]) VALUES (N'123       ', N'a', N'Nam       ', N'TPhcm', N'123123         ', N'123@gamil.com                                     ', CAST(N'1998-12-02 00:00:00.000' AS DateTime), N'NhanVien', CAST(N'2017-11-27 00:00:00.000' AS DateTime), 12)
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
/****** Object:  Trigger [dbo].[trig_ThayDoiTinhTrangBanOn]    Script Date: 11/28/2017 2:38:15 PM ******/
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
/****** Object:  Trigger [dbo].[trig_ThayDoiTinhTrangBanOff]    Script Date: 11/28/2017 2:38:15 PM ******/
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
