CREATE proc [dbo].[BindAllDropdownlists]
@drpType varchar(50)
as
BEGIN
	IF @drpType='dllInvestmentType'
	BEGIN
		SELECT InvestmentTypeID [Id],InvestmentType [Type] FROM InvestmentFormMaster WHERE IsActive=1
	END
	IF @drpType='ddlScheme'
	BEGIN
		SELECT SchemeFormID [Id],SchemeCategory [Type] FROM SchemeFormMaster WHERE IsActive=1 and InvestmentTypeID=1
	END
	if @drpType='ddlNCDType'
	BEGIN
	SELECT SchemeFormID [Id],SchemeFormName [Type] FROM SchemeFormMaster WHERE IsActive=1 and SchemeCategory='NCD'
	END
	if @drpType='ddlSIP'
	BEGIN
	Select * From det_ClientFormTemplateMaster Where CFT_IsActive='1' and CFT_ID in(97,98,99,105,108) 
	END
	if @drpType='dllFieldParameter'
	BEGIN
	SELECT FieldId [Id],ParameterName [Type] FROM [FieldParameter] WHERE IsActive=1
	END
END

CREATE proc [dbo].[BindSchemeCategoryDropdownlists]
@drpType varchar(50),
@InvestmentTypeID int
as
BEGIN
	IF @drpType='dllSchemeCategory'
	BEGIN
		SELECT SchemeFormID [Id],SchemeCategory [Type] FROM SchemeFormMaster WHERE IsActive=1 and InvestmentTypeID=@InvestmentTypeID
	END
END


CREATE proc [dbo].[BindSchemeNameDropdown]
@SchemeCategory varchar(100),
@InvestmentTypeID int
as
BEGIN
	SELECT SchemeFormID [Id],SchemeFormName [Type] FROM SchemeFormMaster WHERE IsActive=1 and InvestmentTypeID=@InvestmentTypeID and SchemeCategory=@SchemeCategory
END

CREATE PROCedure [dbo].[Check_User_Role]
@username varchar(50) =null
as

BEGIN
	
	if exists(Select 1 from UserMaster where username=@username) --and [password]=@password)
	begin
		Select Username,[Role],'True' as flag  from UserMaster where username=@username --and [password]=@password
	end
	else
	begin
		Select @username as Username,'User' as [Role],'False' as flag  from UserMaster --where username=@username --and [password]=@password
	end
END


CREATE proc [dbo].CRUD_EUINNoMappingForm_Master
(
@EUINMappingID int =null,
@InvestmentTypeID int =null,
@SchemeCategory varchar(100)=null,
@SchemeFormName varchar(100)=null,
@EUINApplicable bit=1,
@EUINNo varchar(100)=null,
@status varchar(50)=null,
@UserId varchar(15)=null,
@IsActive bit=1
)
as
BEGIN
    if(@status='add')
	BEGIN
	IF NOT EXISTS(select 1 from [dbo].[EUINNoMappingFormMaster] where  EUINMappingID=@EUINMappingID and IsActive=1)
	BEGIN
		Insert into [dbo].[EUINNoMappingFormMaster] (InvestmentTypeID,SchemeCategoryID,SchemeFormName,EUINApplicable,EUINNo, Created_by,Created_Date,Modified_By,Modified_Date,IsActive)
		values(@InvestmentTypeID,@SchemeCategory,@SchemeFormName,@EUINApplicable,@EUINNo,@UserId,GETDATE(),null,null,@IsActive)

		select 'EUIN No Mapping Form saved successfully' as Message
	END
	ELSE
	BEGIN
		select 'EUIN No Mapping Form already exists' as Message
	END
	END
	ELSE IF(@status='update')
	BEGIN
		IF EXISTS (Select 1 from [dbo].[EUINNoMappingFormMaster] where EUINMappingID<>EUINMappingID and SchemeFormName=@SchemeFormName)
		BEGIN
			select 'Mapping already exists' as Message
		END
	ELSE
	BEGIN
		Update [dbo].[EUINNoMappingFormMaster] 
		SET InvestmentTypeID=@InvestmentTypeID,SchemeCategoryID=@SchemeCategory,SchemeFormName=@SchemeFormName,EUINApplicable=@EUINApplicable,EUINNo=@EUINNo,Modified_By=@UserId,Modified_Date=GETDATE(),IsActive=@IsActive
		where EUINMappingID=@EUINMappingID

		select 'EUIN No Mapping Form updated successfully' as Message

	END
	END
	ELSE IF(@status='list')
	BEGIN
		select s.EUINMappingID,s.InvestmentTypeID,i.InvestmentType,s.SchemeCategoryID,s.SchemeFormName,s.EUINApplicable,
		case 
		when s.[EUINApplicable]=1 Then 'Yes'
		when s.[EUINApplicable]=0 Then 'No'
		END
		AS EUINValue,
		s.EUINNo,
		s.IsActive,
		case 
		when s.IsActive=1 Then 'Active'
		when s.IsActive=0 Then 'InActive'
		END
		AS ModelStatus
		from [dbo].[EUINNoMappingFormMaster] s
		inner join InvestmentFormMaster i on s.InvestmentTypeID=i.InvestmentTypeID
		--inner join SchemeFormMaster j on s.SchemeCategoryID=j.SchemeFormID
	END
	ELSE IF(@status='getbyid')
	BEGIN
		select EUINMappingID,s.InvestmentTypeID,i.InvestmentType,s.SchemeCategoryID,s.SchemeFormName,s.EUINApplicable,
		case 
		when s.[EUINApplicable]=1 Then 'Yes'
		when s.[EUINApplicable]=0 Then 'No'
		END
		AS EUINValue,
		s.EUINNo,s.IsActive,
		case 
		when s.IsActive=1 Then 'Active'
		when s.IsActive=0 Then 'InActive'
		END
		AS ModelStatus
		from [dbo].[EUINNoMappingFormMaster] s
		inner join InvestmentFormMaster i on s.InvestmentTypeID=i.InvestmentTypeID
		--inner join SchemeFormMaster j on s.SchemeCategoryID=j.SchemeFormID
		where EUINMappingID=@EUINMappingID
	END
	--ELSE IF(@type='delete')
	--BEGIN
	--	UPDATE SchemeFormMaster 
	--	SET IsActive=0,Modified_By=@UserId,Modified_Date=GETDATE()  
	--	where SchemeFormID=@SchemeFormID

	--	select 'Scheme Form delete successfully' as Message
	--END
END

CREATE proc [dbo].[CRUD_InvestmentForm_Master]
(
@InvestmentTypeID int =null,
@InvestmentType varchar(100)=null,
@type varchar(50)=null,
@UserId varchar(15)=null,
@IsActive bit=1
)
as
BEGIN
	if(@type='add')
	BEGIN
	IF NOT EXISTS(select 1 from InvestmentFormMaster where  InvestmentType=@InvestmentType and IsActive=1)
	BEGIN
		Insert into InvestmentFormMaster (InvestmentType,Created_by,Created_Date,Modified_By,Modified_Date,IsActive)
		values(@InvestmentType,@UserId,GETDATE(),null,null,@IsActive)

		select 'Investment Form save successfully' as Message
	END
	ELSE
	BEGIN
		select 'Investment Form already exists' as Message
	END
	END
	ELSE IF(@type='update')
	BEGIN
		IF EXISTS (Select 1 from InvestmentFormMaster where InvestmentTypeID<>@InvestmentTypeID and InvestmentType=@InvestmentType)
		BEGIN
			select 'Investment Form exists' as Message
		END
	ELSE
	BEGIN
		Update InvestmentFormMaster 
		SET InvestmentType=@InvestmentType,Modified_By=@UserId,Modified_Date=GETDATE(),IsActive=@IsActive
		where InvestmentTypeID=@InvestmentTypeID

		select 'Investment Form  successfully' as Message

	END
	END
	ELSE IF(@type='list')
	BEGIN
		select InvestmentType,InvestmentTypeID,
		IsActive,
		case 
		when IsActive=1 Then 'Active'
		when IsActive=0 Then 'InActive'
		END
		AS ModelStatus


		 from InvestmentFormMaster 
	END
	ELSE IF(@type='getbyid')
	BEGIN
		select InvestmentType,InvestmentTypeID,IsActive,
		case 
		when IsActive=1 Then 'Active'
		when IsActive=0 Then 'InActive'
		END
		AS ModelStatus  from InvestmentFormMaster where InvestmentTypeID=@InvestmentTypeID
	END
	ELSE IF(@type='delete')
	BEGIN
		UPDATE InvestmentFormMaster SET IsActive=0,Modified_By=@UserId,Modified_Date=GETDATE() where InvestmentTypeID=@InvestmentTypeID

		select 'Investment Form delete successfully' as Message
	END
END


CREATE proc [dbo].CRUD_SchemeConfiguration_Master
(
@SchemeConfigID int =null,
@InvestmentTypeID int =null,
@SchemeCategory varchar(100)=null,
@SchemeFormName varchar(100)=null,
@EUINApplicable bit=1,
@EUINNo varchar(100)=null,
@StartDate datetime=null,
@EndDate datetime=null,
@TotalPages int =null,
@FieldParamter varchar(100)=null,
@FileName varchar(100)=null,
@contentType varchar(100)=null,
@status varchar(50)=null,
@UserId varchar(15)=null,
@IsActive bit=1
)
as
BEGIN
    if(@status='add')
	BEGIN
	IF NOT EXISTS(select 1 from [dbo].[SchemeConfigFormMaster] where  SchemeConfigID=@SchemeConfigID and IsActive=1)
	BEGIN
		Insert into [dbo].[SchemeConfigFormMaster] (InvestmentTypeID,SchemeCategoryID,SchemeFormName,StartDate,EndDate,TotalPages, EUINApplicable,EUINNo,FieldParamter,FileName,contentType, Created_by,Created_Date,Modified_By,Modified_Date,IsActive)
		values(@InvestmentTypeID,@SchemeCategory,@SchemeFormName,@StartDate,@EndDate,@TotalPages,@EUINApplicable,@EUINNo,@FieldParamter,@FileName,@contentType,@UserId,GETDATE(),null,null,@IsActive)

		select 'Configuration saved successfully' as Message
	END
	ELSE
	BEGIN
		select 'Configuration already exists' as Message
	END
	END
	ELSE IF(@status='update')
	BEGIN
		IF EXISTS (Select 1 from [dbo].[SchemeConfigFormMaster] where SchemeConfigID<>SchemeConfigID and SchemeFormName=@SchemeFormName)
		BEGIN
			select 'Configuration already exists' as Message
		END
	ELSE
	BEGIN
		Update [dbo].[SchemeConfigFormMaster] 
		SET InvestmentTypeID=@InvestmentTypeID,SchemeCategoryID=@SchemeCategory,SchemeFormName=@SchemeFormName,EUINApplicable=@EUINApplicable,EUINNo=@EUINNo,Modified_By=@UserId,Modified_Date=GETDATE(),IsActive=@IsActive,
		StartDate=@StartDate,EndDate=@EndDate,TotalPages=@TotalPages,FieldParamter=@FieldParamter,FileName=@FileName,contentType=@contentType
		where SchemeConfigID=@SchemeConfigID

		select 'Configuration updated successfully' as Message

	END
	END
	ELSE IF(@status='list')
	BEGIN
		select s.[SchemeConfigID],s.InvestmentTypeID,i.InvestmentType,s.SchemeCategoryID,s.SchemeFormName,s.EUINApplicable,s.StartDate,
		s.EndDate,s.[TotalPages],s.[FieldParamter],s.[FileName],s.[contentType],
		case 
		when s.[EUINApplicable]=1 Then 'Yes'
		when s.[EUINApplicable]=0 Then 'No'
		END
		AS EUINValue,
		s.EUINNo,
		s.IsActive,
		case 
		when s.IsActive=1 Then 'Active'
		when s.IsActive=0 Then 'InActive'
		END
		AS ModelStatus
		from [dbo].[SchemeConfigFormMaster] s
		inner join InvestmentFormMaster i on s.InvestmentTypeID=i.InvestmentTypeID
		
	END
	ELSE IF(@status='getbyid')
	BEGIN
		select s.[SchemeConfigID],s.InvestmentTypeID,i.InvestmentType,s.SchemeCategoryID,s.SchemeFormName,s.EUINApplicable,s.StartDate,
		s.EndDate,s.[TotalPages],s.[FieldParamter],s.[FileName],s.[contentType],
		case 
		when s.[EUINApplicable]=1 Then 'Yes'
		when s.[EUINApplicable]=0 Then 'No'
		END
		AS EUINValue,
		s.EUINNo,s.IsActive,
		case 
		when s.IsActive=1 Then 'Active'
		when s.IsActive=0 Then 'InActive'
		END
		AS ModelStatus
		from [dbo].[SchemeConfigFormMaster] s
		inner join InvestmentFormMaster i on s.InvestmentTypeID=i.InvestmentTypeID
		--inner join SchemeFormMaster j on s.SchemeCategoryID=j.SchemeFormID
		where [SchemeConfigID]=@SchemeConfigID
	END
	END

CREATE proc [dbo].[CRUD_SchemeForm_Master]
(
@SchemeFormID int =null,
@InvestmentTypeID int =null,
@SchemeCategory varchar(100)=null,
@SchemeFormName varchar(100)=null,
@type varchar(50)=null,
@UserId varchar(15)=null,
@IsActive bit=1
)
as
BEGIN
	if(@type='add')
	BEGIN
	IF NOT EXISTS(select 1 from SchemeFormMaster where  SchemeFormID=@SchemeFormID and IsActive=1)
	BEGIN
		Insert into SchemeFormMaster (InvestmentTypeID,SchemeCategory,SchemeFormName,Created_by,Created_Date,Modified_By,Modified_Date,IsActive)
		values(@InvestmentTypeID,@SchemeCategory,@SchemeFormName,@UserId,GETDATE(),null,null,@IsActive)

		select 'Scheme Form saved successfully' as Message
	END
	ELSE
	BEGIN
		select 'Scheme Form already exists' as Message
	END
	END
	ELSE IF(@type='update')
	BEGIN
		IF EXISTS (Select 1 from SchemeFormMaster where SchemeFormID<>SchemeFormID and SchemeFormName=@SchemeFormName)
		BEGIN
			select 'Scheme Form exists' as Message
		END
	ELSE
	BEGIN
		Update SchemeFormMaster 
		SET InvestmentTypeID=@InvestmentTypeID,SchemeCategory=@SchemeCategory,SchemeFormName=@SchemeFormName,Modified_By=@UserId,Modified_Date=GETDATE(),IsActive=@IsActive
		where SchemeFormID=@SchemeFormID

		select 'Scheme Form updated successfully' as Message

	END
	END
	ELSE IF(@type='list')
	BEGIN
		select SchemeFormID,s.InvestmentTypeID,i.InvestmentType,SchemeCategory,SchemeFormName,
		s.IsActive,
		case 
		when s.IsActive=1 Then 'Active'
		when s.IsActive=0 Then 'InActive'
		END
		AS ModelStatus
		from SchemeFormMaster s
		inner join InvestmentFormMaster i on s.InvestmentTypeID=i.InvestmentTypeID
	END
	ELSE IF(@type='getbyid')
	BEGIN
		select SchemeFormID,s.InvestmentTypeID,i.InvestmentType,SchemeCategory,SchemeFormName,s.IsActive,
		case 
		when s.IsActive=1 Then 'Active'
		when s.IsActive=0 Then 'InActive'
		END
		AS ModelStatus  from SchemeFormMaster s 
		inner join InvestmentFormMaster i on s.InvestmentTypeID=i.InvestmentTypeID 
		where SchemeFormID=@SchemeFormID
	END
	ELSE IF(@type='delete')
	BEGIN
		UPDATE SchemeFormMaster 
		SET IsActive=0,Modified_By=@UserId,Modified_Date=GETDATE()  
		where SchemeFormID=@SchemeFormID

		select 'Scheme Form delete successfully' as Message
	END
END

CREATE PROCEDURE [dbo].[getClientFormDownloadID]      
 @Form_Id AS INT OUT,      
 @userIP nvarchar(50),    
 @CFT_Id char(5)      
 AS      
BEGIN      

      
 SET NOCOUNT ON;      
       
 Set @Form_Id=0      
       
 Select ISNULL(MAX(Form_Id),0) as Message From det_ClientFormDownloads  Where CFT_Id=@CFT_Id    
       
 Declare @CFT_EndNumber int    
 Declare @CFT_StartNumber int    
 Set @CFT_StartNumber=0    
 Set @CFT_EndNumber=0    
    
 Select @CFT_EndNumber=CFT_EndNumber,@CFT_StartNumber=CFT_StartNumber From det_ClientFormTemplateMaster Where CFT_Id=@CFT_Id    
     
       
 IF @Form_Id>=@CFT_EndNumber    --71611001      
  Begin    
  print 'A'  
   Set @Form_Id=0      
  End      
 Else      
 Begin      
     
 if @Form_Id=0    
  Begin    
  print 'B'
    Set @Form_Id=@CFT_StartNumber    
  End     
 Else    
  Begin    
  print 'C'
    Set @Form_Id=@Form_Id+1    
  End    
     
  INSERT INTO det_ClientFormDownloads(Form_Id,Entered_Date,UserIP,CFT_Id) VALUES(@Form_Id,GETDATE(),@userIP,@CFT_Id)      
      
 End      
    Select ISNULL(MAX(Form_Id),0) as Message From det_ClientFormDownloads  Where CFT_Id=@CFT_Id    
        
    IF @Form_Id=@CFT_EndNumber    
    Begin     
       Select 0 as Message    
    End     
END