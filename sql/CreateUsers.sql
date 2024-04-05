INSERT INTO db.AspNetRoles (Id,Name,NormalizedName,ConcurrencyStamp) VALUES
	 ('0bdd04b0-a7b9-4355-ad1b-c33c49fec65f','User','User',NULL),
	 ('0fc1d1a0-d5c6-4a6e-b4d9-e909a503361e','Admin','Admin',NULL),
	 ('41d0df3a-1ef9-4145-936b-b170b69c8c70','Doctor','Doctor',NULL),
	 ('9b347210-75e8-483b-85a5-ed42d6685dc4','LabTechnician','LabTechnician',NULL);

INSERT INTO db.AspNetUsers (Id,FirstName,LastName,Idnp,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount) VALUES
	 ('078cef43-f11c-451e-afbc-3e775f49ba4b','Liam','Taylor','6543219870123','6543219870123','6543219870123',NULL,NULL,0,'AQAAAAIAAYagAAAAEIJqJ8xkAcmo2DT7XdD2vSBDVajRp7mSB1L5Cc0hO6WfGPO+zy/a1OiIittDFL0mbA==','UUEIXD3U5UITUJ4FL2A4CEUAOFYHLHDQ','4ac979c8-7e45-4e74-b439-1be18643e7f1',NULL,0,0,NULL,1,0),
	 ('2b0242b9-91b5-4ea1-9230-720de50bc117','Sophia','Wilson','3214569870123','3214569870123','3214569870123',NULL,NULL,0,'AQAAAAIAAYagAAAAEJ4KGxOrNRuVwJPC85UTqzuW8d4JuW4jf0lD1buOHNlCdoCULNnuXFhAv2vQI9GdGA==','TJHMSJGBEKZE4M73YUJ2J2VIQXIK2472','11d29f05-6cca-48f8-89c0-89a0a9297b08',NULL,0,0,NULL,1,0),
	 ('5a0a6b35-f697-46fc-bfa3-c8e021baec9b','Adam','Davis','9876543210123','9876543210123','9876543210123',NULL,NULL,0,'AQAAAAIAAYagAAAAENDgb6NBwUAhsV2ioC1DeB2Z/VFKtEECsqrZHVFNAQw/oxyjALJRXEKCErYgJ8Kp1g==','SGD67HPXRLGEMGXWRX7ME3ZIV7DPXOII','cb8c781e-fc57-4f04-9807-c674b4f37beb',NULL,0,0,NULL,1,0),
	 ('7588cacf-f307-46e4-a548-ec11358de578','Isabella','Hernandez','2581473690123','2581473690123','2581473690123',NULL,NULL,0,'AQAAAAIAAYagAAAAEH1QcGuM+SVhpP2r1Dvdo3L3Nys/Ljqg5W9dXUmYQoTvk6o9Qlb4S0/hB5H+e1Uw1w==','HYNQFBDPYS47CRIZSYQ7D7HCFJUO7NWZ','bcba235f-da20-4a36-abd0-18f76e634086',NULL,0,0,NULL,1,0),
	 ('cdac45b3-aa72-476e-9fa6-662c30d5df41','super','admin','0000000000000','0000000000000','0000000000000',NULL,NULL,0,'AQAAAAIAAYagAAAAEK+UNsRHuYL8LC8p1UM1194Gf86/WvsmnPeC7XJRYB+c4k3fSRYaJ11Vm8vsZvBiEg==','24WJCGKXJRAJCTXSKREQIKVDZZV5XJPJ','360d9239-9e19-4194-a647-ab5d15217b5c',NULL,0,0,NULL,1,0),
	 ('f17f4eab-59f7-4b48-8f68-0e3cb028dc28','admin','admin','0000000000001','0000000000001','0000000000001',NULL,NULL,0,'AQAAAAIAAYagAAAAENBiC+PQlZEwpJyCEWc5gPN32OWUXLbm4IsoFiqThStZPNdj2ckgtTrq3qiOEZrfEQ==','7VTZE3S7CPL2CT43JC6USRRIRTIINPFQ','06f05bae-b8a2-4a79-bc2b-8e0b0d60c9fb',NULL,0,0,NULL,1,0),
	 ('f3b165f5-2801-41b3-b37f-daa568c0f2f9','Emily','Johnson','1234567890123','1234567890123','1234567890123',NULL,NULL,0,'AQAAAAIAAYagAAAAEPRg6hoIF/Sz0ST7Q5mjwtUDBbQIdYCGAn5LzMsgGB3N7xuLBfkz6BjdSccVTvRt7g==','Q6ITZWBAQH6FYVI5DQZXI2BGIFLQ22F2','6123e7f5-97f5-43ba-b56b-eda019d58a9b',NULL,0,0,NULL,1,0);

INSERT INTO db.AspNetUserRoles (UserId,RoleId) VALUES
	 ('078cef43-f11c-451e-afbc-3e775f49ba4b','0bdd04b0-a7b9-4355-ad1b-c33c49fec65f'),
	 ('2b0242b9-91b5-4ea1-9230-720de50bc117','0bdd04b0-a7b9-4355-ad1b-c33c49fec65f'),
	 ('5a0a6b35-f697-46fc-bfa3-c8e021baec9b','0bdd04b0-a7b9-4355-ad1b-c33c49fec65f'),
	 ('7588cacf-f307-46e4-a548-ec11358de578','0bdd04b0-a7b9-4355-ad1b-c33c49fec65f'),
	 ('cdac45b3-aa72-476e-9fa6-662c30d5df41','0bdd04b0-a7b9-4355-ad1b-c33c49fec65f'),
	 ('f3b165f5-2801-41b3-b37f-daa568c0f2f9','0bdd04b0-a7b9-4355-ad1b-c33c49fec65f'),
	 ('cdac45b3-aa72-476e-9fa6-662c30d5df41','0fc1d1a0-d5c6-4a6e-b4d9-e909a503361e'),
	 ('f17f4eab-59f7-4b48-8f68-0e3cb028dc28','0fc1d1a0-d5c6-4a6e-b4d9-e909a503361e'),
	 ('078cef43-f11c-451e-afbc-3e775f49ba4b','41d0df3a-1ef9-4145-936b-b170b69c8c70'),
	 ('7588cacf-f307-46e4-a548-ec11358de578','41d0df3a-1ef9-4145-936b-b170b69c8c70'),
	 ('cdac45b3-aa72-476e-9fa6-662c30d5df41','41d0df3a-1ef9-4145-936b-b170b69c8c70'),
	 ('2b0242b9-91b5-4ea1-9230-720de50bc117','9b347210-75e8-483b-85a5-ed42d6685dc4'),
	 ('7588cacf-f307-46e4-a548-ec11358de578','9b347210-75e8-483b-85a5-ed42d6685dc4'),
	 ('cdac45b3-aa72-476e-9fa6-662c30d5df41','9b347210-75e8-483b-85a5-ed42d6685dc4');