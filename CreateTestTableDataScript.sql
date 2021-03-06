
  --*********************************** AREAS **********************************
  INSERT INTO [dbo].[Areas] ([DateCreated], [CreatedFrom], [Name])
  VALUES (GetDate(), 'Petrov', 'Area1');

  INSERT INTO [dbo].[Areas] ([DateCreated], [CreatedFrom], [Name])
  VALUES (GetDate(), 'Ivanov', 'Area2');

  INSERT INTO [dbo].[Areas] ([DateCreated], [CreatedFrom], [Name])
  VALUES (GetDate(), 'Sidorov', 'Area3');

  --*********************************** CAR CATEGORIES **********************************
  INSERT INTO [dbo].[CarCategories] ([DateCreated], [CreatedFrom], [Name])
  VALUES (GetDate(), 'Ivanov', 'Category1');

  INSERT INTO [dbo].[CarCategories] ([DateCreated], [CreatedFrom], [Name])
  VALUES (GetDate(), 'Petrov', 'Category2');

  INSERT INTO [dbo].[CarCategories] ([DateCreated], [CreatedFrom], [Name])
  VALUES (GetDate(), 'Sidorov', 'Category3');

  --*********************************** GARAGES **********************************
  INSERT INTO [dbo].[Garages]([DateCreated], [CreatedFrom], [Name], [AreaId], [GarageTypeId])
  VALUES (GetDate(), 'Ivanov', 'Garage1', (SELECT Id  FROM [dbo].[Areas] WHERE Name = 'Area1'), 1);

  INSERT INTO [dbo].[Garages]([DateCreated], [CreatedFrom], [Name], [AreaId], [GarageTypeId])
  VALUES (GetDate(), 'Ivanov', 'Garage2', (SELECT Id  FROM [dbo].[Areas] WHERE Name = 'Area1'), 2);

  INSERT INTO [dbo].[Garages]([DateCreated], [CreatedFrom], [Name], [AreaId], [GarageTypeId])
  VALUES (GetDate(), 'Ivanov', 'Garage3', (SELECT Id  FROM [dbo].[Areas] WHERE Name = 'Area2'), 3);

  INSERT INTO [dbo].[Garages]([DateCreated], [CreatedFrom], [Name], [AreaId], [GarageTypeId])
  VALUES (GetDate(), 'Ivanov', 'Garage4', (SELECT Id  FROM [dbo].[Areas] WHERE Name = 'Area3'), 4);

  --*********************************** CARS **********************************

  INSERT INTO [dbo].[Cars]([DateCreated], [CreatedFrom], [Title], [GarageId], [CategoryId])
  VALUES (GetDate(), 'Ivanov', 'Car1', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage1'), 
  (SELECT Id  FROM [dbo].[CarCategories] WHERE Name = 'Category1'))

  INSERT INTO [dbo].[Cars]([DateCreated], [CreatedFrom], [Title], [GarageId], [CategoryId])
  VALUES (GetDate(), 'Ivanov', 'Car2', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage1'), 
  (SELECT Id  FROM [dbo].[CarCategories] WHERE Name = 'Category2'))

  INSERT INTO [dbo].[Cars]([DateCreated], [CreatedFrom], [Title], [GarageId], [CategoryId])
  VALUES (GetDate(), 'Ivanov', 'Car3', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage1'), 
  (SELECT Id  FROM [dbo].[CarCategories] WHERE Name = 'Category3'))

  INSERT INTO [dbo].[Cars]([DateCreated], [CreatedFrom], [Title], [GarageId], [CategoryId])
  VALUES (GetDate(), 'Ivanov', 'Car1', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage2'), 
  (SELECT Id  FROM [dbo].[CarCategories] WHERE Name = 'Category1'))

  INSERT INTO [dbo].[Cars]([DateCreated], [CreatedFrom], [Title], [GarageId], [CategoryId])
  VALUES (GetDate(), 'Ivanov', 'Car2', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage2'), 
  (SELECT Id  FROM [dbo].[CarCategories] WHERE Name = 'Category2'))

  INSERT INTO [dbo].[Cars]([DateCreated], [CreatedFrom], [Title], [GarageId], [CategoryId])
  VALUES (GetDate(), 'Ivanov', 'Car3', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage2'), 
  (SELECT Id  FROM [dbo].[CarCategories] WHERE Name = 'Category3'))


  INSERT INTO [dbo].[Cars]([DateCreated], [CreatedFrom], [Title], [GarageId], [CategoryId])
  VALUES (GetDate(), 'Ivanov', 'Car1', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage3'), 
  (SELECT Id  FROM [dbo].[CarCategories] WHERE Name = 'Category1'))

  INSERT INTO [dbo].[Cars]([DateCreated], [CreatedFrom], [Title], [GarageId], [CategoryId])
  VALUES (GetDate(), 'Ivanov', 'Car2', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage3'), 
  (SELECT Id  FROM [dbo].[CarCategories] WHERE Name = 'Category2'))

  INSERT INTO [dbo].[Cars]([DateCreated], [CreatedFrom], [Title], [GarageId], [CategoryId])
  VALUES (GetDate(), 'Ivanov', 'Car3', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage3'), 
  (SELECT Id  FROM [dbo].[CarCategories] WHERE Name = 'Category3'))
    INSERT INTO [dbo].[Reports]([DateCreated], [CreatedFrom], [Notes], [GarageId], [ReportTimePeriod])
  VALUES (GetDate(), 'Ivanov', 'ReportNote1', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage1'), '2017')

  --*********************************** REPORTS **********************************
  INSERT INTO [dbo].[Reports]([DateCreated], [CreatedFrom], [Notes], [GarageId], [ReportTimePeriod])
  VALUES (GetDate(), 'Ivanov', 'ReportNote2', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage2'), '2017')

  
  INSERT INTO [dbo].[Reports]([DateCreated], [CreatedFrom], [Notes], [GarageId], [ReportTimePeriod])
  VALUES (GetDate(), 'Ivanov', 'ReportNote3', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage3'), '2017')


  INSERT INTO [dbo].[Reports]([DateCreated], [CreatedFrom], [Notes], [GarageId], [ReportTimePeriod])
  VALUES (GetDate(), 'Ivanov', 'ReportNote4', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage2'), '2016')

  INSERT INTO [dbo].[Reports]([DateCreated], [CreatedFrom], [Notes], [GarageId], [ReportTimePeriod])
  VALUES (GetDate(), 'Ivanov', 'ReportNote5', (SELECT Id  FROM [dbo].[Garages] WHERE Name = 'Garage2'), '2016')