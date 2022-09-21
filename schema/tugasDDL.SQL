CREATE DATABASE SuratPerjalananDinass;

CREATE TABLE admins (
	username VARCHAR (10) not null,
	password VARCHAR (10) not null, 
	UNIQUE (password), 
	PRIMARY KEY (username)
);

CREATE TABLE pegawai(
	idPegawai INT not null IDENTITY(1,1),
	namaPegawai VARCHAR (255) not null,
	nipPegawai INT not null,
	jabawanPegawai VARCHAR (255)not null,
	golonganPegawai VARCHAR (10) not null,
	PRIMARY KEY (idPegawai),
	UNIQUE (nipPegawai)

);

CREATE TABLE suratDinas(
	id INT not null,
	nomor VARCHAR (30) NOT NULL,
	kegiatan INT not null,
	jenis INT not null,
	opsi INT not null,
	pos INT not null,
	PRIMARY KEY (id),
	UNIQUE (nomor)
);
CREATE TABLE pegawaiDinas (
	idDinas INT not null,
	idpegawai INT not null,
	idsurat INT not null,
	PRIMARY KEY (idDinas)
);

ALTER TABLE pegawaiDinas ADD CONSTRAINT FK_id_pegawai FOREIGN KEY 
	(idPegawai) REFERENCES pegawai(idpegawai);

ALTER TABLE pegawaiDinas ADD CONSTRAINT FK_id_surat FOREIGN KEY 
	(idsurat) REFERENCES suratDinas(id);

CREATE TABLE tiketPesawat(
	id INT NOT NULL, 
	hargaTiket INT NOT NULL, 
	ruteAwal VARCHAR (255) NOT NULL, 
	ruteTujuan VARCHAR (255) NOT NULL, 
	PRIMARY KEY (id)
);

CREATE TABLE biayaPenginapan(
	id INT NOT NULL, 
	provinsi INT NOT NULL, 
	eselon1 INT NOT NULL, 
	eselon2 INT NOT NULL, 
	eselon3 INT NOT NULL, 
	eselon4 INT NOT NULL, 
	eselon5 INT NOT NULL, 
	PRIMARY KEY (id)
);

CREATE TABLE uangHarian(
	id INT NOT NULL, 
	provinsi VARCHAR (25) NOT NULL, 
	luarkota INT NOT NULL, 
	dalamkota INT NOT NULL, 
	diklat INT NOT NULL, 
	PRIMARY KEY (id)
);

CREATE TABLE uangRepresentasi(
	id INT NOT NULL, 
	uraian INT NOT NULL, 
	luarkota INT NOT NULL, 
	dalamkota INT NOT NULL, 
	PRIMARY KEY (id)
);

CREATE TABLE biayaTransport(
	id INT NOT NULL,
	provinsi VARCHAR (255),
	PRIMARY KEY (id)
);

CREATE TABLE transportasiLokal(
	id INT NOT NULL,
	provinsi VARCHAR (255),
	ibukota VARCHAR (255),
	kabupaten VARCHAR (255),
	besaran INT,
	PRIMARY KEY (id)
);
CREATE TABLE dataRinci(
	id INT NOT NULL,
	PRIMARY KEY (id),
	idSurat INT NOT NULL,
	CONSTRAINT FK_id_surat_Dinas FOREIGN KEY (idSurat) REFERENCES suratDinas (id),
	nomor VARCHAR (30)
	CONSTRAINT FK_nomor_surat_Dinas FOREIGN KEY (nomor) REFERENCES suratDinas (nomor),
	idPegawai INT NOT NULL,
	tglMulai DATE NOT NULL,
	tglAkhir DATE NOT NULL,
	tglSurat DATE NOT NULL, 
	tempat VARCHAR (255) NOT NULL,
	idHarian INT NOT NULL,
	idPenginapan INT NOT NULL,
	idTiket INT NOT NULL, 
	idTransport INT NOT NULL,
	idLokal INT NOT NULL,
);

ALTER TABLE dataRinci ADD CONSTRAINT FK_id_pegawai2 FOREIGN KEY (idPegawai) REFERENCES pegawai (idPegawai)

ALTER TABLE dataRinci ADD CONSTRAINT FK_id_uangHarian FOREIGN KEY 
	(idHarian) REFERENCES uangHarian(id);

ALTER TABLE dataRinci ADD CONSTRAINT FK_id_biayaPenginapan FOREIGN KEY 
	(idPenginapan) REFERENCES biayaPenginapan(id);

ALTER TABLE dataRinci ADD CONSTRAINT FK_id_biayaTransport FOREIGN KEY 
	(idTransport) REFERENCES biayaTransport(id);

ALTER TABLE dataRinci ADD CONSTRAINT FK_id_Lokal FOREIGN KEY 
	(idLokal) REFERENCES transportasiLokal(id);

ALTER TABLE dataRinci ADD CONSTRAINT FK_tiketPesawat FOREIGN KEY 
	(idTiket) REFERENCES tiketPesawat(id);

drop database MCC;

