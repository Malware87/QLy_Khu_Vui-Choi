create database QL_KhuVuiChoi

go
use QL_KhuVuiChoi
go
--Nếu tạo database rồi thì không cần chạy 4 dòng trên

--Thứ tự tạo bảng: KhuVuiChoi -> NhanVien -> Ve -> DichVu -> TroChoi
create table KhuVuiChoi
(
	MaKhu nvarchar(50) primary key,
	TenKhu nvarchar(50),
	GioMoCua time,
	GioDongCua time,
	ViTri nvarchar(50),
	GiaTE int,
	GiaNL int,
	DienTich int
)

create table Ve
(
	MaVe nvarchar(50)primary key,
	NgayIn date,
	SoTE int,
	SoNL int,
	ThanhTien int,
	MaTD nvarchar(50),
	SDT nvarchar(50),
	GioiTinh nvarchar(50),
	MaKhu nvarchar(50),
	MaNV nvarchar(50),
)

create table DichVu
(
	MaDV nvarchar(50) primary key,
	TenDV nvarchar(50),
	ViTri nvarchar(50),
	GiaTE int,
	GiaNL int,
	MaKhu nvarchar(50),
)

create proc Ve_ins
@MaVe nvarchar(50),
@NgayIn date,
@SoTE int,
@SoNL int,
@ThanhTien int,
@MaTD nvarchar(50),
@SDT nvarchar(50),
@GioiTinh nvarchar(50),
@MaKhu nvarchar(50),
@MaNV nvarchar(50)
as
begin
insert into Ve values (@MaVe,@NgayIn,@SoTE,@SoNL,@ThanhTien,@MaTD,@SDT,@GioiTinh,@MaKhu,@MaNV)
end

create proc Ve_update
@MaVe nvarchar(50),
@NgayIn date,
@SoTE int,
@SoNL int,
@ThanhTien int,
@MaTD nvarchar(50),
@SDT nvarchar(50),
@GioiTinh nvarchar(50),
@MaKhu nvarchar(50),
@MaNV nvarchar(50)
as
begin
update Ve set NgayIn=@NgayIn,SoTE=@SoTE,SoNL=@SoNL,ThanhTien=@ThanhTien,MaTD=@MaTD,SDT=@SDT,GioiTinh=@GioiTinh,MaKhu=@MaKhu,MaNV=@MaNV
where MaVe=@MaVe
end

create proc Ve_del
@MaVe nvarchar(50)
as
begin
delete from Ve where MaVe=@MaVe
end

create proc Ve_find
@MaVe nvarchar(50),
@NgayIn date
as
begin
select * from Ve where MaVe like '%'+@MaVe+'%' and NgayIn=@NgayIn
end

create proc KhuVuiChoi_ins
@MaKhu nvarchar(50),
@TenKhu nvarchar(50),
@GioMoCua time,
@GioDongCua time,
@ViTri nvarchar(50),
@GiaTE int,
@GiaNL int,
@DienTich int
as
begin
insert into KhuVuiChoi values (@MaKhu,@TenKhu,@GioMoCua,@GioDongCua,@ViTri,@GiaTE,@GiaNL,@DienTich)
end

create proc KhuVuiChoi_update
@MaKhu nvarchar(50),
@TenKhu nvarchar(50),
@GioMoCua time,
@GioDongCua time,
@ViTri nvarchar(50),
@GiaTE int,
@GiaNL int,
@DienTich int
as
begin
update KhuVuiChoi set TenKhu=@TenKhu,GioMoCua=@GioMoCua,GioDongCua=@GioDongCua,ViTri=@ViTri,GiaTE=@GiaTE,GiaNL=@GiaNL,DienTich=@DienTich
where MaKhu=@MaKhu
end

create proc KhuVuiChoi_del
@MaKhu nvarchar(50)
as
begin
delete from KhuVuiChoi where MaKhu=@MaKhu
end

create proc KhuVuiChoi_find
@MaKhu nvarchar(50),
@TenKhu nvarchar(50)
as
begin
select * from KhuVuiChoi where MaKhu like '%'+@MaKhu+'%' and TenKhu like '%'+@TenKhu+'%'
end


create proc DichVu_ins
@MaDV nvarchar(50),
@TenDV nvarchar(50),
@ViTri nvarchar(50),
@GiaTE int,
@GiaNL int,
@MaKhu nvarchar(50)
as
begin
insert into DichVu values (@MaDV,@TenDV,@ViTri,@GiaTE,@GiaNL,@MaKhu)
end

create proc DichVu_update
@MaDV nvarchar(50),
@TenDV nvarchar(50),
@ViTri nvarchar(50),
@GiaTE int,
@GiaNL int,
@MaKhu nvarchar(50)
as
begin
update DichVu set TenDV=@TenDV,ViTri=@ViTri,GiaTE=@GiaTE,GiaNL=@GiaNL,MaKhu=@MaKhu
where MaDV=@MaDV
end

create proc DichVu_del
@MaDV nvarchar(50)
as
begin
delete from DichVu where MaDV=@MaDV
end

create proc DichVu_find
@MaDV nvarchar(50),
@TenDV nvarchar(50)
as
begin
select * from DichVu where MaDV like '%'+@MaDV+'%' and TenDV like '%'+@TenDV+'%'
end


create table NhanVien
(
MaNV nvarchar(50) primary key,
HoTen nvarchar(50),
NgaySinh date,
SDT nvarchar(50),
GioiTinh nvarchar(50),
DiaChi nvarchar(50),
ChucVu nvarchar(50),
Luong int,
MaKhu nvarchar(50)
)

create table TroChoi
(
MaTroChoi nvarchar(50) primary key,
TenTro nvarchar(50),
ViTri nvarchar(50),
MaKhu nvarchar(50)
)

create proc NhanVien_ins
@MaNV nvarchar(50),
@HoTen nvarchar(50),
@NgaySinh date,
@SDT nvarchar(50),
@GioiTinh nvarchar(50),
@DiaChi nvarchar(50),
@ChucVu nvarchar(50),
@Luong int,
@MaKhu nvarchar(50)
as
begin
	insert into NhanVien Values(@MaNV,@HoTen,@NgaySinh,@SDT,@GioiTinh,@DiaChi ,@ChucVu ,@Luong ,@MaKhu)
end 

create proc NhanVien_update
@MaNV nvarchar(50),
@HoTen nvarchar(50),
@NgaySinh date,
@SDT nvarchar(50),
@GioiTinh nvarchar(50),
@DiaChi nvarchar(50),
@ChucVu nvarchar(50),
@Luong int,
@MaKhu nvarchar(50)
as 
Begin
	Update NhanVien set HoTen = @HoTen ,NgaySinh = @NgaySinh, SDT = @SDT , GioiTinh = @GioiTinh, DiaChi = @DiaChi ,ChucVu = @ChucVu, Luong = @Luong ,MaKhu = @MaKhu
	Where MaNV= @MaNV
End

create proc NhanVien_del
@MaNV nvarchar(50)
as 
Begin
	Delete from NhanVien
	Where MaNV= @MaNV
End

create proc NhanVien_find
@MaNV nvarchar(50),
@HoTen nvarchar(50),
@SDT nvarchar(50),
@GioiTinh nvarchar(50),
@DiaChi nvarchar(50),
@ChucVu nvarchar(50),
@Luong int,
@MaKhu nvarchar(50)
as 
begin
		Select *
		From NhanVien
		Where MaNV like '%'+@MaNV+'%' and HoTen like '%'+@HoTen+'%' and SDT like '%'+@SDT+'%'and GioiTinh like '%'+@GioiTinh+'%' and ChucVu like '%'+@ChucVu+'%' and Luong like '%'+@Luong+'%' and MaKhu like '%'+@MaKhu+'%'
end

create proc TroChoi_ins
@MaTroChoi nvarchar(50),
@TenTro nvarchar(50),
@ViTri nvarchar(50),
@MaKhu nvarchar(50)
as
begin
	insert into TroChoi Values(@MaTroChoi,@TenTro,@ViTri,@MaKhu)
end 

create proc TroChoi_Update
@MaTroChoi nvarchar(50),
@TenTro nvarchar(50),
@ViTri nvarchar(50),
@MaKhu nvarchar(50)
as 
Begin
	Update TroChoi set TenTro = @TenTro ,ViTri = @ViTri, MaKhu = @MaKhu
	Where MaTroChoi= @MaTroChoi
End

Create proc TroChoi_del
@MaTroChoi char(5)
as 
Begin
	Delete from TroChoi
	Where MaTroChoi= @MaTroChoi
End

create proc TroChoi_find
@MaTroChoi nvarchar(50),
@TenTro nvarchar(50),
@ViTri nvarchar(50),
@MaKhu nvarchar(50)
as 
begin
		Select *
		From TroChoi
		Where MaTroChoi like '%'+@MaTroChoi+'%' and TenTro like '%'+@TenTro+'%' and ViTri like '%'+@ViTri+'%' and MaKhu like '%'+@MaKhu+'%'
end
select * from NhanVien
 exec NhanVien_ins 'NV001','Nguyen Van A','12/1/2000','0123456789','Nam','Ha Noi','Giam Doc','1000000','KV001'
 //
 
CREATE TABLE TaiKhoan(
    TaiKhoan varchar(50) NOT NULL,
    MatKhau nvarchar(50) NOT NULL,
    IDPer int ,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
    TaiKhoan ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
drop table TaiKhoan

create proc Checklogin
@Username nvarchar(20),
@Password nvarchar(20)
as
begin
    if exists (select * from TaiKhoan where TaiKhoan = @Username and MatKhau = @Password and IDPer = 1)
        select 1 as code
    else if exists (select * from TaiKhoan where TaiKhoan = @Username and MatKhau = @Password and IDPer = 0)
        select 0 as code
    else if exists(select * from TaiKhoan where TaiKhoan = @Username and MatKhau != @Password) 
        select 2 as code
    else select 3 as code
end

