USE [HatcheryDB]
GO
INSERT [dbo].[Breeds] ([Id], [Name], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'50fc6a12-41d6-48be-ab04-30de42094bb5', N'new breed', CAST(N'2018-03-19T16:35:24.030' AS DateTime), NULL, CAST(N'2018-03-19T16:35:27.063' AS DateTime))
GO
INSERT [dbo].[Breeds] ([Id], [Name], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'53c11a18-fc17-4a4e-929e-59ef245a7305', N'Kuroiler', CAST(N'2018-01-09T15:37:02.000' AS DateTime), CAST(N'2018-03-19T16:46:08.450' AS DateTime), NULL)
GO
INSERT [dbo].[Breeds] ([Id], [Name], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'96812cdc-9570-451d-a131-fe16711e3f00', N'Broiler', CAST(N'2018-01-09T15:36:58.907' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Breeds] ([Id], [Name], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'd8300014-8415-4984-80f7-a0f106313bf4', N'First Breeds', CAST(N'2018-03-12T15:06:41.000' AS DateTime), CAST(N'2018-03-12T15:06:48.650' AS DateTime), NULL)
GO
INSERT [dbo].[BreedTypes] ([Id], [BreedId], [BreedType], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'0d44e2dd-1335-4673-99c8-702898604d40', N'96812cdc-9570-451d-a131-fe16711e3f00', N'New Breed type', CAST(N'2018-03-19T16:35:41.633' AS DateTime), NULL, CAST(N'2018-03-19T16:35:44.720' AS DateTime))
GO
INSERT [dbo].[BreedTypes] ([Id], [BreedId], [BreedType], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'145f9575-6145-4523-88e3-7be31c3b7671', N'53c11a18-fc17-4a4e-929e-59ef245a7305', N'kuroiler 2', CAST(N'2018-01-10T14:58:52.940' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BreedTypes] ([Id], [BreedId], [BreedType], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'53ad095c-b6ad-41f7-9fdc-2c37997d6283', N'53c11a18-fc17-4a4e-929e-59ef245a7305', N'kuroiler 1', CAST(N'2018-01-10T14:58:44.257' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BreedTypes] ([Id], [BreedId], [BreedType], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'bb24a987-f7c2-491f-aa1c-8405daa7ea07', N'96812cdc-9570-451d-a131-fe16711e3f00', N'cobb 500', CAST(N'2018-01-09T15:37:53.673' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BreedTypes] ([Id], [BreedId], [BreedType], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'ebdcc77a-31df-4ca5-bb24-bd165838ed56', N'96812cdc-9570-451d-a131-fe16711e3f00', N'cobb 600', CAST(N'2018-01-09T15:38:03.823' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Countries] ([Id], [CountryName], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'1254018c-7e3f-4fd5-ae6e-d9aff13bc3d6', N'Nepal', CAST(N'2018-01-09T15:37:33.607' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Countries] ([Id], [CountryName], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'23a5b9a0-6478-453c-aec4-dcce7f7f4f82', N'Indias', CAST(N'2018-03-19T16:35:54.000' AS DateTime), CAST(N'2018-03-19T16:35:58.733' AS DateTime), CAST(N'2018-03-19T16:36:00.617' AS DateTime))
GO
INSERT [dbo].[Countries] ([Id], [CountryName], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'59c9a25c-f2ba-41c1-ba51-79689ba8e2db', N'Thailand', CAST(N'2018-01-09T15:37:37.310' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Batches] ([Id], [Code], [CountryId], [ArrivalDate], [Age], [BreedId], [BreedTypeId], [TotalMale], [TotalFemale], [DeadMale], [DeadFemale], [TotalCost], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'a853cd82-3563-4a30-aca1-887fc02b9233', N'B-2074-1', N'1254018c-7e3f-4fd5-ae6e-d9aff13bc3d6', CAST(N'2018-04-01T00:00:00.000' AS DateTime), 2, N'96812cdc-9570-451d-a131-fe16711e3f00', N'bb24a987-f7c2-491f-aa1c-8405daa7ea07', 45, 4565, 1, 2, 400000, CAST(N'2018-04-03T14:31:35.477' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Batches] ([Id], [Code], [CountryId], [ArrivalDate], [Age], [BreedId], [BreedTypeId], [TotalMale], [TotalFemale], [DeadMale], [DeadFemale], [TotalCost], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'f70f0e2d-b27c-4414-97fb-427f52292e1a', N'2074', N'59c9a25c-f2ba-41c1-ba51-79689ba8e2db', CAST(N'2018-04-03T00:00:00.000' AS DateTime), 0, N'53c11a18-fc17-4a4e-929e-59ef245a7305', N'53ad095c-b6ad-41f7-9fdc-2c37997d6283', 234, 200, 33, 44, 42452, CAST(N'2018-04-03T13:55:59.577' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Feeds] ([Id], [FeedName], [Price], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'228f0aa9-707d-4116-bc62-f7b0f2ff4843', N'B3', 67, CAST(N'2018-03-09T16:22:20.550' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Feeds] ([Id], [FeedName], [Price], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'2a7496fa-b572-4d5a-b3f6-42e2327a9afe', N'B1', 34, CAST(N'2018-03-09T16:22:00.160' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Feeds] ([Id], [FeedName], [Price], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'555b5a04-5ea5-4168-8823-6450813f45c5', N'a', 12, CAST(N'2018-03-09T16:06:26.193' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Feeds] ([Id], [FeedName], [Price], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'90d11d3f-2916-4872-a008-8a3e3502c5d5', N'a', 12, CAST(N'2018-03-09T16:06:25.670' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BreedFeeds] ([Id], [BreedId], [FeedId], [FeedName], [GenderId], [Gender], [Age], [MaleQuantity], [FemaleQuantity], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'087ce8f5-b9f7-4420-b6c2-1eb18de5ba08', N'53c11a18-fc17-4a4e-929e-59ef245a7305', N'2a7496fa-b572-4d5a-b3f6-42e2327a9afe', NULL, NULL, NULL, 1, 2, 3, CAST(N'2018-04-03T13:58:46.550' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BreedFeeds] ([Id], [BreedId], [FeedId], [FeedName], [GenderId], [Gender], [Age], [MaleQuantity], [FemaleQuantity], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'b577885c-ac03-4d2c-86bf-53e41ca55401', N'53c11a18-fc17-4a4e-929e-59ef245a7305', N'2a7496fa-b572-4d5a-b3f6-42e2327a9afe', NULL, NULL, NULL, 1, 2, 3, CAST(N'2018-04-03T13:58:45.753' AS DateTime), NULL, CAST(N'2018-04-03T13:58:51.240' AS DateTime))
GO
INSERT [dbo].[BreedFeeds] ([Id], [BreedId], [FeedId], [FeedName], [GenderId], [Gender], [Age], [MaleQuantity], [FemaleQuantity], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'e9ff411d-de73-4e98-9dc1-adb16f23f954', N'96812cdc-9570-451d-a131-fe16711e3f00', N'2a7496fa-b572-4d5a-b3f6-42e2327a9afe', NULL, NULL, NULL, 1, 3, 4, CAST(N'2018-04-04T15:38:46.850' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Vaccines] ([Id], [VaccineName], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'141cd03c-0d23-48af-93e5-5f4c99003d43', N'Marecks', CAST(N'2018-01-09T15:37:10.177' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Vaccines] ([Id], [VaccineName], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'41516d5c-d715-403a-95d0-f8669ce32453', N'Gambura', CAST(N'2018-01-09T15:37:16.317' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Vaccines] ([Id], [VaccineName], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'9a8b9d6b-e95b-43ee-8904-0527a8d1ea2b', N'F1', CAST(N'2018-03-19T16:36:12.987' AS DateTime), CAST(N'2018-03-19T16:36:12.987' AS DateTime), NULL)
GO
INSERT [dbo].[Vaccines] ([Id], [VaccineName], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'ccea2307-cec8-4b28-ba02-22e5953cc662', N'Litchi', CAST(N'2018-04-03T15:31:33.277' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Vaccines] ([Id], [VaccineName], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'fcc869b1-54ec-497d-8edc-7f3cdfbb8fe6', N'New Vaccine', CAST(N'2018-03-19T16:36:19.440' AS DateTime), NULL, CAST(N'2018-03-19T16:36:22.377' AS DateTime))
GO
INSERT [dbo].[BreedVaccines] ([Id], [BreedId], [VaccineId], [Age], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'04a1f3b0-2218-42d1-bba0-9458adbe0df6', N'96812cdc-9570-451d-a131-fe16711e3f00', N'9a8b9d6b-e95b-43ee-8904-0527a8d1ea2b', 2, CAST(N'2018-04-03T15:32:11.703' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BreedVaccines] ([Id], [BreedId], [VaccineId], [Age], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'052684e1-68ef-428d-a06c-d28223c4ea2f', N'53c11a18-fc17-4a4e-929e-59ef245a7305', N'9a8b9d6b-e95b-43ee-8904-0527a8d1ea2b', 2, CAST(N'2018-04-03T15:36:30.420' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BreedVaccines] ([Id], [BreedId], [VaccineId], [Age], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'50e995fa-ea8a-472c-9f04-809757441f70', N'96812cdc-9570-451d-a131-fe16711e3f00', N'41516d5c-d715-403a-95d0-f8669ce32453', 3, CAST(N'2018-04-03T15:32:19.687' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BreedVaccines] ([Id], [BreedId], [VaccineId], [Age], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'8a27e96e-228b-4577-8bea-14128222b89a', N'96812cdc-9570-451d-a131-fe16711e3f00', N'141cd03c-0d23-48af-93e5-5f4c99003d43', 1, CAST(N'2018-04-03T15:32:03.920' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BreedVaccines] ([Id], [BreedId], [VaccineId], [Age], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'9602adc8-1319-4a61-8569-0d033344ef06', N'53c11a18-fc17-4a4e-929e-59ef245a7305', N'141cd03c-0d23-48af-93e5-5f4c99003d43', 1, CAST(N'2018-04-03T15:36:22.870' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Medicines] ([Id], [MedicineName], [DiseaseName], [RecomendedDoctor], [BreedId], [Date], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'e6f9eec1-46b2-4b28-b558-529241ded2d5', N'Med-1', N'Des-1', N'Bikrams', N'53c11a18-fc17-4a4e-929e-59ef245a7305', CAST(N'2018-03-19T00:00:00.000' AS DateTime), CAST(N'2018-03-19T16:36:39.000' AS DateTime), CAST(N'2018-03-19T16:36:46.807' AS DateTime), NULL)
GO
INSERT [dbo].[HatcheryFarms] ([Id], [Name], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'93833cd6-a6f7-4421-a9af-009dac2c18b6', N'Quality Farms', CAST(N'2018-01-09T15:35:57.000' AS DateTime), CAST(N'2018-03-19T16:34:33.330' AS DateTime), NULL)
GO
INSERT [dbo].[HatcheryFarms] ([Id], [Name], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'b8c64f4f-247a-4636-9520-867c8413b5f8', N'New Farm', CAST(N'2018-03-19T16:34:42.370' AS DateTime), NULL, CAST(N'2018-03-19T16:34:46.957' AS DateTime))
GO
INSERT [dbo].[HatcheryFarms] ([Id], [Name], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'cafef7b5-e635-4a02-b59d-d615cbd42443', N'Ktm hatchery farm', CAST(N'2018-01-10T13:29:56.537' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Locations] ([Id], [HatcheryFarmId], [Location], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'1ebd36e1-bd78-4346-a0aa-43dd5899f15a', N'cafef7b5-e635-4a02-b59d-d615cbd42443', N'K Room1', CAST(N'2018-01-10T15:00:52.000' AS DateTime), CAST(N'2018-03-19T16:35:00.927' AS DateTime), NULL)
GO
INSERT [dbo].[Locations] ([Id], [HatcheryFarmId], [Location], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'2b73086b-d00e-4221-8020-e2cb17afb81d', N'93833cd6-a6f7-4421-a9af-009dac2c18b6', N'Q room1', CAST(N'2018-01-09T15:36:09.803' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Locations] ([Id], [HatcheryFarmId], [Location], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'4249babc-800d-47f3-b9d8-2cbce75049b1', N'93833cd6-a6f7-4421-a9af-009dac2c18b6', N'Q room2', CAST(N'2018-01-09T15:36:12.900' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[Locations] ([Id], [HatcheryFarmId], [Location], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'86fc8544-e934-4f7d-b380-bd1f36b4923e', N'cafef7b5-e635-4a02-b59d-d615cbd42443', N'new location', CAST(N'2018-03-19T16:35:12.487' AS DateTime), NULL, CAST(N'2018-03-19T16:35:14.783' AS DateTime))
GO
INSERT [dbo].[Locations] ([Id], [HatcheryFarmId], [Location], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'd408ec7f-4277-492e-b974-a5b1fbcad50b', N'cafef7b5-e635-4a02-b59d-d615cbd42443', N'K Room2', CAST(N'2018-04-03T14:32:52.133' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BatchChicken] ([Id], [BatchId], [FarmId], [LocationId], [TotalMale], [TotalFemale], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'3708e5e0-7f9b-4b90-bfa2-5fb69e844e39', N'a853cd82-3563-4a30-aca1-887fc02b9233', N'cafef7b5-e635-4a02-b59d-d615cbd42443', N'1ebd36e1-bd78-4346-a0aa-43dd5899f15a', 34, 54, CAST(N'2018-04-03T14:32:27.603' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BatchChicken] ([Id], [BatchId], [FarmId], [LocationId], [TotalMale], [TotalFemale], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'422d0377-1192-486a-bafd-d442c01017df', N'a853cd82-3563-4a30-aca1-887fc02b9233', N'cafef7b5-e635-4a02-b59d-d615cbd42443', N'd408ec7f-4277-492e-b974-a5b1fbcad50b', 31, 57, CAST(N'2018-04-03T14:40:44.577' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[BatchChicken] ([Id], [BatchId], [FarmId], [LocationId], [TotalMale], [TotalFemale], [DateCreated], [DateUpdated], [DateDeleted]) VALUES (N'5b24a687-f2ce-452b-b409-b39cb2228169', N'f70f0e2d-b27c-4414-97fb-427f52292e1a', N'93833cd6-a6f7-4421-a9af-009dac2c18b6', N'2b73086b-d00e-4221-8020-e2cb17afb81d', 134, 441, CAST(N'2018-04-03T13:56:28.657' AS DateTime), NULL, NULL)
GO
INSERT [dbo].[ChickenFeeds] ([Id], [BatchId], [LocationId], [FeedId], [Age], [MaleQuantity], [FemaleQuantity], [DateEntry], [RecommendedDate], [DateCreated], [DateUpdated], [DateDeleted], [BreedFeeds_Id]) VALUES (N'62969bf5-dddc-455a-a6e3-99734e7e8d63', N'f70f0e2d-b27c-4414-97fb-427f52292e1a', N'2b73086b-d00e-4221-8020-e2cb17afb81d', N'2a7496fa-b572-4d5a-b3f6-42e2327a9afe', 0, 65, 0, CAST(N'2018-04-04T00:00:00.000' AS DateTime), CAST(N'2018-04-04T16:05:29.213' AS DateTime), CAST(N'2018-04-04T16:05:29.213' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[ChickenFeeds] ([Id], [BatchId], [LocationId], [FeedId], [Age], [MaleQuantity], [FemaleQuantity], [DateEntry], [RecommendedDate], [DateCreated], [DateUpdated], [DateDeleted], [BreedFeeds_Id]) VALUES (N'8fb501bf-5437-4953-b0f8-3219fb690464', N'f70f0e2d-b27c-4414-97fb-427f52292e1a', N'2b73086b-d00e-4221-8020-e2cb17afb81d', N'2a7496fa-b572-4d5a-b3f6-42e2327a9afe', 0, 0, 0, CAST(N'2018-04-03T00:00:00.000' AS DateTime), CAST(N'2018-04-03T14:31:22.663' AS DateTime), CAST(N'2018-04-03T14:31:22.663' AS DateTime), NULL, CAST(N'2018-04-03T16:16:55.520' AS DateTime), NULL)
GO
INSERT [dbo].[ChickenFeeds] ([Id], [BatchId], [LocationId], [FeedId], [Age], [MaleQuantity], [FemaleQuantity], [DateEntry], [RecommendedDate], [DateCreated], [DateUpdated], [DateDeleted], [BreedFeeds_Id]) VALUES (N'a3de3a6c-3455-4624-82d8-c4a008f29b3b', N'f70f0e2d-b27c-4414-97fb-427f52292e1a', N'2b73086b-d00e-4221-8020-e2cb17afb81d', N'2a7496fa-b572-4d5a-b3f6-42e2327a9afe', 0, 12, 21, CAST(N'2018-04-03T00:00:00.000' AS DateTime), CAST(N'2018-04-03T14:01:33.073' AS DateTime), CAST(N'2018-04-03T14:01:33.073' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[ChickenFeeds] ([Id], [BatchId], [LocationId], [FeedId], [Age], [MaleQuantity], [FemaleQuantity], [DateEntry], [RecommendedDate], [DateCreated], [DateUpdated], [DateDeleted], [BreedFeeds_Id]) VALUES (N'b72fb4ee-bcfb-4847-a20f-1263e82fc50f', N'f70f0e2d-b27c-4414-97fb-427f52292e1a', N'2b73086b-d00e-4221-8020-e2cb17afb81d', N'2a7496fa-b572-4d5a-b3f6-42e2327a9afe', 0, 54, 0, CAST(N'2018-04-03T00:00:00.000' AS DateTime), CAST(N'2018-04-03T16:16:42.740' AS DateTime), CAST(N'2018-04-03T16:16:42.740' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[ChickenVaccines] ([Id], [BatchId], [LocationId], [VaccineId], [Age], [VaccinationDate], [RecommendedDate], [DateCreated], [DateUpdated], [DateDeleted], [BreedVaccine_Id]) VALUES (N'2efbfd98-577a-43a5-b815-3a8f0be59c8c', N'f70f0e2d-b27c-4414-97fb-427f52292e1a', N'2b73086b-d00e-4221-8020-e2cb17afb81d', N'9a8b9d6b-e95b-43ee-8904-0527a8d1ea2b', 0, CAST(N'2018-04-04T00:00:00.000' AS DateTime), CAST(N'2018-04-05T00:00:00.000' AS DateTime), CAST(N'2018-04-04T17:02:17.267' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[ChickenVaccines] ([Id], [BatchId], [LocationId], [VaccineId], [Age], [VaccinationDate], [RecommendedDate], [DateCreated], [DateUpdated], [DateDeleted], [BreedVaccine_Id]) VALUES (N'59eadc45-33a5-45a1-a906-72becb19db14', N'a853cd82-3563-4a30-aca1-887fc02b9233', N'd408ec7f-4277-492e-b974-a5b1fbcad50b', N'9a8b9d6b-e95b-43ee-8904-0527a8d1ea2b', 0, CAST(N'2018-04-04T00:00:00.000' AS DateTime), CAST(N'2018-04-03T00:00:00.000' AS DateTime), CAST(N'2018-04-04T15:53:00.813' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[ChickenVaccines] ([Id], [BatchId], [LocationId], [VaccineId], [Age], [VaccinationDate], [RecommendedDate], [DateCreated], [DateUpdated], [DateDeleted], [BreedVaccine_Id]) VALUES (N'5edac331-68f2-4039-8404-e8a58f16e23f', N'a853cd82-3563-4a30-aca1-887fc02b9233', N'd408ec7f-4277-492e-b974-a5b1fbcad50b', N'141cd03c-0d23-48af-93e5-5f4c99003d43', 0, CAST(N'2018-04-04T00:00:00.000' AS DateTime), CAST(N'2018-04-02T00:00:00.000' AS DateTime), CAST(N'2018-04-04T15:51:59.823' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[ChickenVaccines] ([Id], [BatchId], [LocationId], [VaccineId], [Age], [VaccinationDate], [RecommendedDate], [DateCreated], [DateUpdated], [DateDeleted], [BreedVaccine_Id]) VALUES (N'a3e229cd-bdab-4d84-ad3f-23f318846b7c', N'f70f0e2d-b27c-4414-97fb-427f52292e1a', N'2b73086b-d00e-4221-8020-e2cb17afb81d', N'141cd03c-0d23-48af-93e5-5f4c99003d43', 0, CAST(N'2018-04-04T00:00:00.000' AS DateTime), CAST(N'2018-04-04T00:00:00.000' AS DateTime), CAST(N'2018-04-04T17:01:03.447' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[ChickenVaccines] ([Id], [BatchId], [LocationId], [VaccineId], [Age], [VaccinationDate], [RecommendedDate], [DateCreated], [DateUpdated], [DateDeleted], [BreedVaccine_Id]) VALUES (N'c1b5a71d-5c28-4c83-9ee1-a94a910b7606', N'a853cd82-3563-4a30-aca1-887fc02b9233', N'1ebd36e1-bd78-4346-a0aa-43dd5899f15a', N'141cd03c-0d23-48af-93e5-5f4c99003d43', 0, CAST(N'2018-04-04T00:00:00.000' AS DateTime), CAST(N'2018-04-02T00:00:00.000' AS DateTime), CAST(N'2018-04-04T15:51:58.080' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[ChickenVaccines] ([Id], [BatchId], [LocationId], [VaccineId], [Age], [VaccinationDate], [RecommendedDate], [DateCreated], [DateUpdated], [DateDeleted], [BreedVaccine_Id]) VALUES (N'cb928942-03a6-4eba-a0a2-c177d62e87d4', N'a853cd82-3563-4a30-aca1-887fc02b9233', N'1ebd36e1-bd78-4346-a0aa-43dd5899f15a', N'9a8b9d6b-e95b-43ee-8904-0527a8d1ea2b', 0, CAST(N'2018-04-04T00:00:00.000' AS DateTime), CAST(N'2018-04-03T00:00:00.000' AS DateTime), CAST(N'2018-04-04T15:52:59.937' AS DateTime), NULL, NULL, NULL)
GO
