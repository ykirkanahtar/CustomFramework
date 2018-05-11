namespace CustomFramework.WebApiCodeGenerator
{
    partial class FrmCodeGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblNameSpace = new System.Windows.Forms.Label();
            this.TxtNameSpace = new System.Windows.Forms.TextBox();
            this.LblClassName = new System.Windows.Forms.Label();
            this.TxtClassName = new System.Windows.Forms.TextBox();
            this.LblPrimaryKey = new System.Windows.Forms.Label();
            this.RdInt32 = new System.Windows.Forms.RadioButton();
            this.RdLong = new System.Windows.Forms.RadioButton();
            this.GrpKeys = new System.Windows.Forms.GroupBox();
            this.BtnClass = new System.Windows.Forms.Button();
            this.GrpClass = new System.Windows.Forms.GroupBox();
            this.ChkHasUpdateMethod = new System.Windows.Forms.CheckBox();
            this.ChkGetAllWithPaging = new System.Windows.Forms.CheckBox();
            this.ChkHasGetAllMethod = new System.Windows.Forms.CheckBox();
            this.GrpField = new System.Windows.Forms.GroupBox();
            this.BtnCreateField = new System.Windows.Forms.Button();
            this.ChkIsUnique = new System.Windows.Forms.CheckBox();
            this.ChkHasGetMethod = new System.Windows.Forms.CheckBox();
            this.ChkAddToResponse = new System.Windows.Forms.CheckBox();
            this.ChkAddToRequest = new System.Windows.Forms.CheckBox();
            this.ChkNotNull = new System.Windows.Forms.CheckBox();
            this.TxtFieldLength = new System.Windows.Forms.TextBox();
            this.LblFieldLength = new System.Windows.Forms.Label();
            this.CmbFieldDataTypes = new System.Windows.Forms.ComboBox();
            this.LblDataType = new System.Windows.Forms.Label();
            this.TxtFieldName = new System.Windows.Forms.TextBox();
            this.LblFieldName = new System.Windows.Forms.Label();
            this.LstViewFields = new System.Windows.Forms.ListView();
            this.BtnCreateFiles = new System.Windows.Forms.Button();
            this.LblStatus = new System.Windows.Forms.Label();
            this.GrpVirtualList = new System.Windows.Forms.GroupBox();
            this.TxtRefClassName = new System.Windows.Forms.TextBox();
            this.LblRefClassName = new System.Windows.Forms.Label();
            this.GrpRefDataType = new System.Windows.Forms.GroupBox();
            this.RdRefInt64 = new System.Windows.Forms.RadioButton();
            this.RdRefInt32 = new System.Windows.Forms.RadioButton();
            this.LstViewReferences = new System.Windows.Forms.ListView();
            this.ChkRefIsUnique = new System.Windows.Forms.CheckBox();
            this.ChkRefHasGet = new System.Windows.Forms.CheckBox();
            this.ChkRefAddToResponse = new System.Windows.Forms.CheckBox();
            this.ChkRefAddToRequest = new System.Windows.Forms.CheckBox();
            this.ChkRefNotNull = new System.Windows.Forms.CheckBox();
            this.GrpReferences = new System.Windows.Forms.GroupBox();
            this.RdOneToOne = new System.Windows.Forms.RadioButton();
            this.RdManyToOne = new System.Windows.Forms.RadioButton();
            this.RdManyToMany = new System.Windows.Forms.RadioButton();
            this.RdOneToMany = new System.Windows.Forms.RadioButton();
            this.TxtRefName = new System.Windows.Forms.TextBox();
            this.LblRefName = new System.Windows.Forms.Label();
            this.BtnAddOneToManyRef = new System.Windows.Forms.Button();
            this.TxtProjectFolder = new System.Windows.Forms.TextBox();
            this.LblProjectFolder = new System.Windows.Forms.Label();
            this.GrpKeys.SuspendLayout();
            this.GrpClass.SuspendLayout();
            this.GrpField.SuspendLayout();
            this.GrpVirtualList.SuspendLayout();
            this.GrpRefDataType.SuspendLayout();
            this.GrpReferences.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblNameSpace
            // 
            this.LblNameSpace.AutoSize = true;
            this.LblNameSpace.Location = new System.Drawing.Point(12, 9);
            this.LblNameSpace.Name = "LblNameSpace";
            this.LblNameSpace.Size = new System.Drawing.Size(69, 13);
            this.LblNameSpace.TabIndex = 0;
            this.LblNameSpace.Text = "NameSpace:";
            // 
            // TxtNameSpace
            // 
            this.TxtNameSpace.Location = new System.Drawing.Point(87, 6);
            this.TxtNameSpace.Name = "TxtNameSpace";
            this.TxtNameSpace.ReadOnly = true;
            this.TxtNameSpace.Size = new System.Drawing.Size(239, 20);
            this.TxtNameSpace.TabIndex = 1;
            // 
            // LblClassName
            // 
            this.LblClassName.AutoSize = true;
            this.LblClassName.Location = new System.Drawing.Point(6, 27);
            this.LblClassName.Name = "LblClassName";
            this.LblClassName.Size = new System.Drawing.Size(63, 13);
            this.LblClassName.TabIndex = 2;
            this.LblClassName.Text = "Class Name";
            // 
            // TxtClassName
            // 
            this.TxtClassName.Location = new System.Drawing.Point(75, 24);
            this.TxtClassName.Name = "TxtClassName";
            this.TxtClassName.Size = new System.Drawing.Size(236, 20);
            this.TxtClassName.TabIndex = 3;
            // 
            // LblPrimaryKey
            // 
            this.LblPrimaryKey.AutoSize = true;
            this.LblPrimaryKey.Location = new System.Drawing.Point(7, 71);
            this.LblPrimaryKey.Name = "LblPrimaryKey";
            this.LblPrimaryKey.Size = new System.Drawing.Size(62, 13);
            this.LblPrimaryKey.TabIndex = 5;
            this.LblPrimaryKey.Text = "Primary Key";
            // 
            // RdInt32
            // 
            this.RdInt32.AutoSize = true;
            this.RdInt32.Checked = true;
            this.RdInt32.Location = new System.Drawing.Point(6, 19);
            this.RdInt32.Name = "RdInt32";
            this.RdInt32.Size = new System.Drawing.Size(58, 17);
            this.RdInt32.TabIndex = 5;
            this.RdInt32.TabStop = true;
            this.RdInt32.Text = "Integer";
            this.RdInt32.UseVisualStyleBackColor = true;
            // 
            // RdLong
            // 
            this.RdLong.AutoSize = true;
            this.RdLong.Location = new System.Drawing.Point(70, 19);
            this.RdLong.Name = "RdLong";
            this.RdLong.Size = new System.Drawing.Size(49, 17);
            this.RdLong.TabIndex = 6;
            this.RdLong.Text = "Long";
            this.RdLong.UseVisualStyleBackColor = true;
            // 
            // GrpKeys
            // 
            this.GrpKeys.Controls.Add(this.RdLong);
            this.GrpKeys.Controls.Add(this.RdInt32);
            this.GrpKeys.Location = new System.Drawing.Point(75, 50);
            this.GrpKeys.Name = "GrpKeys";
            this.GrpKeys.Size = new System.Drawing.Size(123, 52);
            this.GrpKeys.TabIndex = 4;
            this.GrpKeys.TabStop = false;
            // 
            // BtnClass
            // 
            this.BtnClass.Location = new System.Drawing.Point(236, 131);
            this.BtnClass.Name = "BtnClass";
            this.BtnClass.Size = new System.Drawing.Size(75, 23);
            this.BtnClass.TabIndex = 10;
            this.BtnClass.Text = "CreateClass";
            this.BtnClass.UseVisualStyleBackColor = true;
            this.BtnClass.Click += new System.EventHandler(this.BtnClass_Click);
            // 
            // GrpClass
            // 
            this.GrpClass.Controls.Add(this.ChkHasUpdateMethod);
            this.GrpClass.Controls.Add(this.ChkGetAllWithPaging);
            this.GrpClass.Controls.Add(this.ChkHasGetAllMethod);
            this.GrpClass.Controls.Add(this.LblClassName);
            this.GrpClass.Controls.Add(this.BtnClass);
            this.GrpClass.Controls.Add(this.TxtClassName);
            this.GrpClass.Controls.Add(this.GrpKeys);
            this.GrpClass.Controls.Add(this.LblPrimaryKey);
            this.GrpClass.Location = new System.Drawing.Point(15, 32);
            this.GrpClass.Name = "GrpClass";
            this.GrpClass.Size = new System.Drawing.Size(322, 176);
            this.GrpClass.TabIndex = 10;
            this.GrpClass.TabStop = false;
            this.GrpClass.Text = "Class Info";
            // 
            // ChkHasUpdateMethod
            // 
            this.ChkHasUpdateMethod.AutoSize = true;
            this.ChkHasUpdateMethod.Location = new System.Drawing.Point(75, 131);
            this.ChkHasUpdateMethod.Name = "ChkHasUpdateMethod";
            this.ChkHasUpdateMethod.Size = new System.Drawing.Size(83, 17);
            this.ChkHasUpdateMethod.TabIndex = 9;
            this.ChkHasUpdateMethod.Text = "Has Update";
            this.ChkHasUpdateMethod.UseVisualStyleBackColor = true;
            // 
            // ChkGetAllWithPaging
            // 
            this.ChkGetAllWithPaging.AutoSize = true;
            this.ChkGetAllWithPaging.Location = new System.Drawing.Point(199, 108);
            this.ChkGetAllWithPaging.Name = "ChkGetAllWithPaging";
            this.ChkGetAllWithPaging.Size = new System.Drawing.Size(118, 17);
            this.ChkGetAllWithPaging.TabIndex = 8;
            this.ChkGetAllWithPaging.Text = "Get All With Paging";
            this.ChkGetAllWithPaging.UseVisualStyleBackColor = true;
            this.ChkGetAllWithPaging.Visible = false;
            this.ChkGetAllWithPaging.VisibleChanged += new System.EventHandler(this.ChkGetAllWithPaging_VisibleChanged);
            // 
            // ChkHasGetAllMethod
            // 
            this.ChkHasGetAllMethod.AutoSize = true;
            this.ChkHasGetAllMethod.Location = new System.Drawing.Point(75, 108);
            this.ChkHasGetAllMethod.Name = "ChkHasGetAllMethod";
            this.ChkHasGetAllMethod.Size = new System.Drawing.Size(118, 17);
            this.ChkHasGetAllMethod.TabIndex = 7;
            this.ChkHasGetAllMethod.Text = "Has Get All Method";
            this.ChkHasGetAllMethod.UseVisualStyleBackColor = true;
            this.ChkHasGetAllMethod.CheckedChanged += new System.EventHandler(this.ChkHasGetAllMethod_CheckedChanged);
            // 
            // GrpField
            // 
            this.GrpField.Controls.Add(this.BtnCreateField);
            this.GrpField.Controls.Add(this.ChkIsUnique);
            this.GrpField.Controls.Add(this.ChkHasGetMethod);
            this.GrpField.Controls.Add(this.ChkAddToResponse);
            this.GrpField.Controls.Add(this.ChkAddToRequest);
            this.GrpField.Controls.Add(this.ChkNotNull);
            this.GrpField.Controls.Add(this.TxtFieldLength);
            this.GrpField.Controls.Add(this.LblFieldLength);
            this.GrpField.Controls.Add(this.CmbFieldDataTypes);
            this.GrpField.Controls.Add(this.LblDataType);
            this.GrpField.Controls.Add(this.TxtFieldName);
            this.GrpField.Controls.Add(this.LblFieldName);
            this.GrpField.Enabled = false;
            this.GrpField.Location = new System.Drawing.Point(343, 32);
            this.GrpField.Name = "GrpField";
            this.GrpField.Size = new System.Drawing.Size(496, 177);
            this.GrpField.TabIndex = 11;
            this.GrpField.TabStop = false;
            this.GrpField.Text = "FieldInfo";
            // 
            // BtnCreateField
            // 
            this.BtnCreateField.Location = new System.Drawing.Point(339, 142);
            this.BtnCreateField.Name = "BtnCreateField";
            this.BtnCreateField.Size = new System.Drawing.Size(151, 23);
            this.BtnCreateField.TabIndex = 25;
            this.BtnCreateField.Text = "CreateField";
            this.BtnCreateField.UseVisualStyleBackColor = true;
            this.BtnCreateField.Click += new System.EventHandler(this.BtnCreateField_Click);
            // 
            // ChkIsUnique
            // 
            this.ChkIsUnique.AutoSize = true;
            this.ChkIsUnique.Location = new System.Drawing.Point(343, 119);
            this.ChkIsUnique.Name = "ChkIsUnique";
            this.ChkIsUnique.Size = new System.Drawing.Size(71, 17);
            this.ChkIsUnique.TabIndex = 22;
            this.ChkIsUnique.Text = "Is Unique";
            this.ChkIsUnique.UseVisualStyleBackColor = true;
            // 
            // ChkHasGetMethod
            // 
            this.ChkHasGetMethod.AutoSize = true;
            this.ChkHasGetMethod.Location = new System.Drawing.Point(343, 96);
            this.ChkHasGetMethod.Name = "ChkHasGetMethod";
            this.ChkHasGetMethod.Size = new System.Drawing.Size(104, 17);
            this.ChkHasGetMethod.TabIndex = 21;
            this.ChkHasGetMethod.Text = "Has Get Method";
            this.ChkHasGetMethod.UseVisualStyleBackColor = true;
            // 
            // ChkAddToResponse
            // 
            this.ChkAddToResponse.AutoSize = true;
            this.ChkAddToResponse.Location = new System.Drawing.Point(343, 73);
            this.ChkAddToResponse.Name = "ChkAddToResponse";
            this.ChkAddToResponse.Size = new System.Drawing.Size(140, 17);
            this.ChkAddToResponse.TabIndex = 20;
            this.ChkAddToResponse.Text = "Add To Response Class";
            this.ChkAddToResponse.UseVisualStyleBackColor = true;
            // 
            // ChkAddToRequest
            // 
            this.ChkAddToRequest.AutoSize = true;
            this.ChkAddToRequest.Location = new System.Drawing.Point(343, 50);
            this.ChkAddToRequest.Name = "ChkAddToRequest";
            this.ChkAddToRequest.Size = new System.Drawing.Size(132, 17);
            this.ChkAddToRequest.TabIndex = 19;
            this.ChkAddToRequest.Text = "Add To Request Class";
            this.ChkAddToRequest.UseVisualStyleBackColor = true;
            // 
            // ChkNotNull
            // 
            this.ChkNotNull.AutoSize = true;
            this.ChkNotNull.Location = new System.Drawing.Point(343, 27);
            this.ChkNotNull.Name = "ChkNotNull";
            this.ChkNotNull.Size = new System.Drawing.Size(64, 17);
            this.ChkNotNull.TabIndex = 18;
            this.ChkNotNull.Text = "Not Null";
            this.ChkNotNull.UseVisualStyleBackColor = true;
            // 
            // TxtFieldLength
            // 
            this.TxtFieldLength.Enabled = false;
            this.TxtFieldLength.Location = new System.Drawing.Point(72, 102);
            this.TxtFieldLength.Name = "TxtFieldLength";
            this.TxtFieldLength.Size = new System.Drawing.Size(55, 20);
            this.TxtFieldLength.TabIndex = 17;
            this.TxtFieldLength.EnabledChanged += new System.EventHandler(this.TxtFieldLength_EnabledChanged);
            // 
            // LblFieldLength
            // 
            this.LblFieldLength.AutoSize = true;
            this.LblFieldLength.Location = new System.Drawing.Point(6, 105);
            this.LblFieldLength.Name = "LblFieldLength";
            this.LblFieldLength.Size = new System.Drawing.Size(65, 13);
            this.LblFieldLength.TabIndex = 16;
            this.LblFieldLength.Text = "Field Length";
            // 
            // CmbFieldDataTypes
            // 
            this.CmbFieldDataTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFieldDataTypes.FormattingEnabled = true;
            this.CmbFieldDataTypes.Location = new System.Drawing.Point(75, 65);
            this.CmbFieldDataTypes.Name = "CmbFieldDataTypes";
            this.CmbFieldDataTypes.Size = new System.Drawing.Size(230, 21);
            this.CmbFieldDataTypes.TabIndex = 15;
            this.CmbFieldDataTypes.SelectedIndexChanged += new System.EventHandler(this.CmbFieldDataTypes_SelectedIndexChanged);
            // 
            // LblDataType
            // 
            this.LblDataType.AutoSize = true;
            this.LblDataType.Location = new System.Drawing.Point(6, 68);
            this.LblDataType.Name = "LblDataType";
            this.LblDataType.Size = new System.Drawing.Size(60, 13);
            this.LblDataType.TabIndex = 14;
            this.LblDataType.Text = "Data Type:";
            // 
            // TxtFieldName
            // 
            this.TxtFieldName.Location = new System.Drawing.Point(75, 28);
            this.TxtFieldName.Name = "TxtFieldName";
            this.TxtFieldName.Size = new System.Drawing.Size(230, 20);
            this.TxtFieldName.TabIndex = 13;
            // 
            // LblFieldName
            // 
            this.LblFieldName.AutoSize = true;
            this.LblFieldName.Location = new System.Drawing.Point(6, 31);
            this.LblFieldName.Name = "LblFieldName";
            this.LblFieldName.Size = new System.Drawing.Size(63, 13);
            this.LblFieldName.TabIndex = 12;
            this.LblFieldName.Text = "Field Name:";
            // 
            // LstViewFields
            // 
            this.LstViewFields.Location = new System.Drawing.Point(12, 215);
            this.LstViewFields.Name = "LstViewFields";
            this.LstViewFields.Size = new System.Drawing.Size(827, 304);
            this.LstViewFields.TabIndex = 12;
            this.LstViewFields.UseCompatibleStateImageBehavior = false;
            this.LstViewFields.DoubleClick += new System.EventHandler(this.LstViewFields_DoubleClick);
            // 
            // BtnCreateFiles
            // 
            this.BtnCreateFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCreateFiles.Location = new System.Drawing.Point(12, 533);
            this.BtnCreateFiles.Name = "BtnCreateFiles";
            this.BtnCreateFiles.Size = new System.Drawing.Size(1231, 23);
            this.BtnCreateFiles.TabIndex = 13;
            this.BtnCreateFiles.Text = "Create Files";
            this.BtnCreateFiles.UseVisualStyleBackColor = true;
            this.BtnCreateFiles.Click += new System.EventHandler(this.BtnCreateFiles_Click);
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(12, 492);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(0, 13);
            this.LblStatus.TabIndex = 14;
            // 
            // GrpVirtualList
            // 
            this.GrpVirtualList.Controls.Add(this.TxtRefClassName);
            this.GrpVirtualList.Controls.Add(this.LblRefClassName);
            this.GrpVirtualList.Controls.Add(this.GrpRefDataType);
            this.GrpVirtualList.Controls.Add(this.LstViewReferences);
            this.GrpVirtualList.Controls.Add(this.ChkRefIsUnique);
            this.GrpVirtualList.Controls.Add(this.ChkRefHasGet);
            this.GrpVirtualList.Controls.Add(this.ChkRefAddToResponse);
            this.GrpVirtualList.Controls.Add(this.ChkRefAddToRequest);
            this.GrpVirtualList.Controls.Add(this.ChkRefNotNull);
            this.GrpVirtualList.Controls.Add(this.GrpReferences);
            this.GrpVirtualList.Controls.Add(this.TxtRefName);
            this.GrpVirtualList.Controls.Add(this.LblRefName);
            this.GrpVirtualList.Controls.Add(this.BtnAddOneToManyRef);
            this.GrpVirtualList.Location = new System.Drawing.Point(845, 34);
            this.GrpVirtualList.Name = "GrpVirtualList";
            this.GrpVirtualList.Size = new System.Drawing.Size(398, 485);
            this.GrpVirtualList.TabIndex = 15;
            this.GrpVirtualList.TabStop = false;
            // 
            // TxtRefClassName
            // 
            this.TxtRefClassName.Location = new System.Drawing.Point(70, 13);
            this.TxtRefClassName.Name = "TxtRefClassName";
            this.TxtRefClassName.Size = new System.Drawing.Size(155, 20);
            this.TxtRefClassName.TabIndex = 31;
            // 
            // LblRefClassName
            // 
            this.LblRefClassName.AutoSize = true;
            this.LblRefClassName.Location = new System.Drawing.Point(12, 16);
            this.LblRefClassName.Name = "LblRefClassName";
            this.LblRefClassName.Size = new System.Drawing.Size(52, 13);
            this.LblRefClassName.TabIndex = 30;
            this.LblRefClassName.Text = "Ref Class";
            // 
            // GrpRefDataType
            // 
            this.GrpRefDataType.Controls.Add(this.RdRefInt64);
            this.GrpRefDataType.Controls.Add(this.RdRefInt32);
            this.GrpRefDataType.Location = new System.Drawing.Point(9, 48);
            this.GrpRefDataType.Name = "GrpRefDataType";
            this.GrpRefDataType.Size = new System.Drawing.Size(123, 40);
            this.GrpRefDataType.TabIndex = 29;
            this.GrpRefDataType.TabStop = false;
            this.GrpRefDataType.Text = "Data Type";
            // 
            // RdRefInt64
            // 
            this.RdRefInt64.AutoSize = true;
            this.RdRefInt64.Location = new System.Drawing.Point(70, 18);
            this.RdRefInt64.Name = "RdRefInt64";
            this.RdRefInt64.Size = new System.Drawing.Size(49, 17);
            this.RdRefInt64.TabIndex = 7;
            this.RdRefInt64.Text = "Long";
            this.RdRefInt64.UseVisualStyleBackColor = true;
            // 
            // RdRefInt32
            // 
            this.RdRefInt32.AutoSize = true;
            this.RdRefInt32.Checked = true;
            this.RdRefInt32.Location = new System.Drawing.Point(6, 18);
            this.RdRefInt32.Name = "RdRefInt32";
            this.RdRefInt32.Size = new System.Drawing.Size(58, 17);
            this.RdRefInt32.TabIndex = 6;
            this.RdRefInt32.TabStop = true;
            this.RdRefInt32.Text = "Integer";
            this.RdRefInt32.UseVisualStyleBackColor = true;
            // 
            // LstViewReferences
            // 
            this.LstViewReferences.Location = new System.Drawing.Point(6, 181);
            this.LstViewReferences.Name = "LstViewReferences";
            this.LstViewReferences.Size = new System.Drawing.Size(385, 298);
            this.LstViewReferences.TabIndex = 28;
            this.LstViewReferences.UseCompatibleStateImageBehavior = false;
            this.LstViewReferences.DoubleClick += new System.EventHandler(this.LstViewReferences_DoubleClick);
            // 
            // ChkRefIsUnique
            // 
            this.ChkRefIsUnique.AutoSize = true;
            this.ChkRefIsUnique.Location = new System.Drawing.Point(251, 108);
            this.ChkRefIsUnique.Name = "ChkRefIsUnique";
            this.ChkRefIsUnique.Size = new System.Drawing.Size(71, 17);
            this.ChkRefIsUnique.TabIndex = 27;
            this.ChkRefIsUnique.Text = "Is Unique";
            this.ChkRefIsUnique.UseVisualStyleBackColor = true;
            // 
            // ChkRefHasGet
            // 
            this.ChkRefHasGet.AutoSize = true;
            this.ChkRefHasGet.Location = new System.Drawing.Point(251, 85);
            this.ChkRefHasGet.Name = "ChkRefHasGet";
            this.ChkRefHasGet.Size = new System.Drawing.Size(104, 17);
            this.ChkRefHasGet.TabIndex = 26;
            this.ChkRefHasGet.Text = "Has Get Method";
            this.ChkRefHasGet.UseVisualStyleBackColor = true;
            // 
            // ChkRefAddToResponse
            // 
            this.ChkRefAddToResponse.AutoSize = true;
            this.ChkRefAddToResponse.Location = new System.Drawing.Point(251, 62);
            this.ChkRefAddToResponse.Name = "ChkRefAddToResponse";
            this.ChkRefAddToResponse.Size = new System.Drawing.Size(140, 17);
            this.ChkRefAddToResponse.TabIndex = 25;
            this.ChkRefAddToResponse.Text = "Add To Response Class";
            this.ChkRefAddToResponse.UseVisualStyleBackColor = true;
            // 
            // ChkRefAddToRequest
            // 
            this.ChkRefAddToRequest.AutoSize = true;
            this.ChkRefAddToRequest.Location = new System.Drawing.Point(251, 39);
            this.ChkRefAddToRequest.Name = "ChkRefAddToRequest";
            this.ChkRefAddToRequest.Size = new System.Drawing.Size(132, 17);
            this.ChkRefAddToRequest.TabIndex = 24;
            this.ChkRefAddToRequest.Text = "Add To Request Class";
            this.ChkRefAddToRequest.UseVisualStyleBackColor = true;
            // 
            // ChkRefNotNull
            // 
            this.ChkRefNotNull.AutoSize = true;
            this.ChkRefNotNull.Location = new System.Drawing.Point(251, 16);
            this.ChkRefNotNull.Name = "ChkRefNotNull";
            this.ChkRefNotNull.Size = new System.Drawing.Size(64, 17);
            this.ChkRefNotNull.TabIndex = 23;
            this.ChkRefNotNull.Text = "Not Null";
            this.ChkRefNotNull.UseVisualStyleBackColor = true;
            // 
            // GrpReferences
            // 
            this.GrpReferences.Controls.Add(this.RdOneToOne);
            this.GrpReferences.Controls.Add(this.RdManyToOne);
            this.GrpReferences.Controls.Add(this.RdManyToMany);
            this.GrpReferences.Controls.Add(this.RdOneToMany);
            this.GrpReferences.Location = new System.Drawing.Point(9, 99);
            this.GrpReferences.Name = "GrpReferences";
            this.GrpReferences.Size = new System.Drawing.Size(221, 47);
            this.GrpReferences.TabIndex = 21;
            this.GrpReferences.TabStop = false;
            this.GrpReferences.Text = "Relation";
            // 
            // RdOneToOne
            // 
            this.RdOneToOne.AutoSize = true;
            this.RdOneToOne.Location = new System.Drawing.Point(149, 22);
            this.RdOneToOne.Name = "RdOneToOne";
            this.RdOneToOne.Size = new System.Drawing.Size(40, 17);
            this.RdOneToOne.TabIndex = 3;
            this.RdOneToOne.TabStop = true;
            this.RdOneToOne.Text = "1-1";
            this.RdOneToOne.UseVisualStyleBackColor = true;
            this.RdOneToOne.CheckedChanged += new System.EventHandler(this.RdOneToOne_CheckedChanged);
            // 
            // RdManyToOne
            // 
            this.RdManyToOne.AutoSize = true;
            this.RdManyToOne.Location = new System.Drawing.Point(103, 22);
            this.RdManyToOne.Name = "RdManyToOne";
            this.RdManyToOne.Size = new System.Drawing.Size(40, 17);
            this.RdManyToOne.TabIndex = 2;
            this.RdManyToOne.TabStop = true;
            this.RdManyToOne.Text = "n-1";
            this.RdManyToOne.UseVisualStyleBackColor = true;
            this.RdManyToOne.CheckedChanged += new System.EventHandler(this.RdManyToOne_CheckedChanged);
            // 
            // RdManyToMany
            // 
            this.RdManyToMany.AutoSize = true;
            this.RdManyToMany.Location = new System.Drawing.Point(57, 22);
            this.RdManyToMany.Name = "RdManyToMany";
            this.RdManyToMany.Size = new System.Drawing.Size(40, 17);
            this.RdManyToMany.TabIndex = 1;
            this.RdManyToMany.TabStop = true;
            this.RdManyToMany.Text = "n-n";
            this.RdManyToMany.UseVisualStyleBackColor = true;
            this.RdManyToMany.CheckedChanged += new System.EventHandler(this.RdManyToMany_CheckedChanged);
            // 
            // RdOneToMany
            // 
            this.RdOneToMany.AutoSize = true;
            this.RdOneToMany.Location = new System.Drawing.Point(11, 22);
            this.RdOneToMany.Name = "RdOneToMany";
            this.RdOneToMany.Size = new System.Drawing.Size(40, 17);
            this.RdOneToMany.TabIndex = 0;
            this.RdOneToMany.TabStop = true;
            this.RdOneToMany.Text = "1-n";
            this.RdOneToMany.UseVisualStyleBackColor = true;
            this.RdOneToMany.CheckedChanged += new System.EventHandler(this.RdOneToMany_CheckedChanged);
            // 
            // TxtRefName
            // 
            this.TxtRefName.Location = new System.Drawing.Point(79, 154);
            this.TxtRefName.Name = "TxtRefName";
            this.TxtRefName.Size = new System.Drawing.Size(155, 20);
            this.TxtRefName.TabIndex = 15;
            // 
            // LblRefName
            // 
            this.LblRefName.AutoSize = true;
            this.LblRefName.Location = new System.Drawing.Point(17, 157);
            this.LblRefName.Name = "LblRefName";
            this.LblRefName.Size = new System.Drawing.Size(63, 13);
            this.LblRefName.TabIndex = 14;
            this.LblRefName.Text = "Field Name:";
            // 
            // BtnAddOneToManyRef
            // 
            this.BtnAddOneToManyRef.Location = new System.Drawing.Point(251, 152);
            this.BtnAddOneToManyRef.Name = "BtnAddOneToManyRef";
            this.BtnAddOneToManyRef.Size = new System.Drawing.Size(140, 23);
            this.BtnAddOneToManyRef.TabIndex = 0;
            this.BtnAddOneToManyRef.Text = "Add Ref";
            this.BtnAddOneToManyRef.UseVisualStyleBackColor = true;
            this.BtnAddOneToManyRef.Click += new System.EventHandler(this.BtnAddOneToManyRef_Click);
            // 
            // TxtProjectFolder
            // 
            this.TxtProjectFolder.Location = new System.Drawing.Point(427, 6);
            this.TxtProjectFolder.Name = "TxtProjectFolder";
            this.TxtProjectFolder.ReadOnly = true;
            this.TxtProjectFolder.Size = new System.Drawing.Size(239, 20);
            this.TxtProjectFolder.TabIndex = 17;
            // 
            // LblProjectFolder
            // 
            this.LblProjectFolder.AutoSize = true;
            this.LblProjectFolder.Location = new System.Drawing.Point(349, 9);
            this.LblProjectFolder.Name = "LblProjectFolder";
            this.LblProjectFolder.Size = new System.Drawing.Size(72, 13);
            this.LblProjectFolder.TabIndex = 16;
            this.LblProjectFolder.Text = "Project Folder";
            // 
            // FrmCodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 577);
            this.Controls.Add(this.TxtProjectFolder);
            this.Controls.Add(this.LblProjectFolder);
            this.Controls.Add(this.GrpVirtualList);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.BtnCreateFiles);
            this.Controls.Add(this.LstViewFields);
            this.Controls.Add(this.GrpField);
            this.Controls.Add(this.GrpClass);
            this.Controls.Add(this.TxtNameSpace);
            this.Controls.Add(this.LblNameSpace);
            this.Name = "FrmCodeGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Generator";
            this.Load += new System.EventHandler(this.frmCodeGenerator_Load);
            this.GrpKeys.ResumeLayout(false);
            this.GrpKeys.PerformLayout();
            this.GrpClass.ResumeLayout(false);
            this.GrpClass.PerformLayout();
            this.GrpField.ResumeLayout(false);
            this.GrpField.PerformLayout();
            this.GrpVirtualList.ResumeLayout(false);
            this.GrpVirtualList.PerformLayout();
            this.GrpRefDataType.ResumeLayout(false);
            this.GrpRefDataType.PerformLayout();
            this.GrpReferences.ResumeLayout(false);
            this.GrpReferences.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblNameSpace;
        private System.Windows.Forms.TextBox TxtNameSpace;
        private System.Windows.Forms.Label LblClassName;
        private System.Windows.Forms.TextBox TxtClassName;
        private System.Windows.Forms.Label LblPrimaryKey;
        private System.Windows.Forms.RadioButton RdInt32;
        private System.Windows.Forms.RadioButton RdLong;
        private System.Windows.Forms.GroupBox GrpKeys;
        private System.Windows.Forms.Button BtnClass;
        private System.Windows.Forms.GroupBox GrpClass;
        private System.Windows.Forms.GroupBox GrpField;
        private System.Windows.Forms.ComboBox CmbFieldDataTypes;
        private System.Windows.Forms.Label LblDataType;
        private System.Windows.Forms.TextBox TxtFieldName;
        private System.Windows.Forms.Label LblFieldName;
        private System.Windows.Forms.Label LblFieldLength;
        private System.Windows.Forms.TextBox TxtFieldLength;
        private System.Windows.Forms.CheckBox ChkNotNull;
        private System.Windows.Forms.CheckBox ChkAddToResponse;
        private System.Windows.Forms.CheckBox ChkAddToRequest;
        private System.Windows.Forms.CheckBox ChkIsUnique;
        private System.Windows.Forms.CheckBox ChkHasGetMethod;
        private System.Windows.Forms.CheckBox ChkGetAllWithPaging;
        private System.Windows.Forms.CheckBox ChkHasGetAllMethod;
        private System.Windows.Forms.Button BtnCreateField;
        private System.Windows.Forms.ListView LstViewFields;
        private System.Windows.Forms.Button BtnCreateFiles;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.GroupBox GrpVirtualList;
        private System.Windows.Forms.Button BtnAddOneToManyRef;
        private System.Windows.Forms.TextBox TxtRefName;
        private System.Windows.Forms.Label LblRefName;
        private System.Windows.Forms.CheckBox ChkHasUpdateMethod;
        private System.Windows.Forms.GroupBox GrpReferences;
        private System.Windows.Forms.RadioButton RdOneToOne;
        private System.Windows.Forms.RadioButton RdManyToOne;
        private System.Windows.Forms.RadioButton RdManyToMany;
        private System.Windows.Forms.RadioButton RdOneToMany;
        private System.Windows.Forms.CheckBox ChkRefIsUnique;
        private System.Windows.Forms.CheckBox ChkRefHasGet;
        private System.Windows.Forms.CheckBox ChkRefAddToResponse;
        private System.Windows.Forms.CheckBox ChkRefAddToRequest;
        private System.Windows.Forms.CheckBox ChkRefNotNull;
        private System.Windows.Forms.ListView LstViewReferences;
        private System.Windows.Forms.GroupBox GrpRefDataType;
        private System.Windows.Forms.RadioButton RdRefInt64;
        private System.Windows.Forms.RadioButton RdRefInt32;
        private System.Windows.Forms.TextBox TxtRefClassName;
        private System.Windows.Forms.Label LblRefClassName;
        private System.Windows.Forms.TextBox TxtProjectFolder;
        private System.Windows.Forms.Label LblProjectFolder;
    }
}

