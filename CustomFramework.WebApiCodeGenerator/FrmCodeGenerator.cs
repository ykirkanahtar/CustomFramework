using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace CustomFramework.WebApiCodeGenerator
{
    public partial class FrmCodeGenerator : Form
    {
        private string _nameSpace;

        private readonly string[] _fieldDataTypes =
        {
            "bool", "DateTime", "decimal", "enum", "int", "long", "string", "reference"
        };

        private string _projectPath;
        private string _projectName;

        //private readonly string _applicationPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\output";

        public FrmCodeGenerator()
        {
            InitializeComponent();
        }

        private void Load_Datas()
        {
            //TxtNameSpace.Text = @"CS.FaceDetection.WebApi"; 
            TxtNameSpace.Text = @"Cs.Crm.WebApi";

            _nameSpace = TxtNameSpace.Text;

            //TxtProjectFolder.Text = @"C:\Users\ykirk\Documents\Projects\FaceDetection.WebApi\CS.FaceDetection.WebApi\CS.FaceDetection.WebApi";
            TxtProjectFolder.Text = @"C:\Users\ykirk\Documents\Projects\Crm\CS.Crm\Cs.Crm.WebApi";

            _projectPath = TxtProjectFolder.Text;

            //LoadStudentData();
            //LoadCourseData();
            //LoadTeacherData();
            //LoadStudentCourseData();
        }

        //    private void LoadStudentData()
        //    {
        //        TxtClassName.Text = @"Student";
        //        RdInt32.Checked = true;
        //        ChkHasGetAllMethod.Checked = true;
        //        ChkGetAllWithPaging.Checked = true;
        //        ChkHasUpdateMethod.Checked = true;

        //        var fieldNo = new Field("StudentNo", "int", string.Empty, true, true, true, true, true);
        //        var fieldName = new Field("Name", "string", "25", true, true, true, false, false);
        //        var fieldSurname = new Field("Surname", "string", "25", true, true, true, false, false);

        //        LstViewFields.Items.Add(new ListViewItem(FieldToListRow(fieldNo)));
        //        LstViewFields.Items.Add(new ListViewItem(FieldToListRow(fieldName)));
        //        LstViewFields.Items.Add(new ListViewItem(FieldToListRow(fieldSurname)));

        //        var referenceCourse = new Reference("StudentCourses", "int", Relations.OneToMany, false, false,
        //            false, false, false, "StudentCourse");

        //        LstViewReferences.Items.Add(new ListViewItem(RefToListRow(referenceCourse)));
        //    }

        //    private void LoadCourseData()
        //    {
        //        TxtClassName.Text = @"Course";
        //        RdInt32.Checked = true;
        //        ChkHasGetAllMethod.Checked = true;
        //        ChkGetAllWithPaging.Checked = false;
        //        ChkHasUpdateMethod.Checked = true;

        //        var fieldNo = new Field("CourseNo", "int", string.Empty, true, true, true, true, true);
        //        var fieldName = new Field("Name", "string", "25", true, true, true, false, false);

        //        LstViewFields.Items.Add(new ListViewItem(FieldToListRow(fieldNo)));
        //        LstViewFields.Items.Add(new ListViewItem(FieldToListRow(fieldName)));

        //        var referenceTeacher = new Reference("TeacherId", "int", Relations.ManyToOne, true, true,
        //true, true, false, "Teacher");
        //        var referenceStudent = new Reference("StudentCourses", "int", Relations.OneToMany, false, false,
        //            false, false, false, "StudentCourse");

        //        LstViewReferences.Items.Add(new ListViewItem(RefToListRow(referenceTeacher)));
        //        LstViewReferences.Items.Add(new ListViewItem(RefToListRow(referenceStudent)));
        //    }

        //    private void LoadTeacherData()
        //    {
        //        TxtClassName.Text = @"Teacher";
        //        RdInt32.Checked = true;
        //        ChkHasGetAllMethod.Checked = true;
        //        ChkGetAllWithPaging.Checked = false;
        //        ChkHasUpdateMethod.Checked = true;

        //        var fieldNo = new Field("TeacherNo", "int", string.Empty, true, true, true, true, true);
        //        var fieldName = new Field("Name", "string", "25", true, true, true, false, false);
        //        var fieldSurname = new Field("Surname", "string", "25", true, true, true, false, false);

        //        LstViewFields.Items.Add(new ListViewItem(FieldToListRow(fieldNo)));
        //        LstViewFields.Items.Add(new ListViewItem(FieldToListRow(fieldName)));
        //        LstViewFields.Items.Add(new ListViewItem(FieldToListRow(fieldSurname)));

        //        var referenceCourse = new Reference("Courses", "int", Relations.ManyToMany, false, false,
        //            false, false, false, "Course");

        //        LstViewReferences.Items.Add(new ListViewItem(RefToListRow(referenceCourse)));
        //    }

        private void LoadStudentCourseData()
        {
            TxtClassName.Text = @"StudentCourse";
            RdInt32.Checked = true;
            ChkHasGetAllMethod.Checked = false;
            ChkGetAllWithPaging.Checked = false;
            ChkHasUpdateMethod.Checked = false;

            var referenceStudent = new Reference("StudentId", "int", Relations.ManyToOne, true, true,
true, true, false, "Student");
            var referenceCourse = new Reference("CourseId", "int", Relations.ManyToOne, true, true,
    true, true, false, "Course");

            LstViewReferences.Items.Add(new ListViewItem(RefToListRow(referenceStudent)));
            LstViewReferences.Items.Add(new ListViewItem(RefToListRow(referenceCourse)));
        }

        private void AddToListView(Field field)
        {
            LstViewFields.Items.Add(new ListViewItem(FieldToListRow(field)));
        }

        private void AddRefToListView(Reference reference)
        {
            LstViewReferences.Items.Add(new ListViewItem(RefToListRow(reference)));
        }

        private static string[] FieldToListRow(Field field)
        {
            string[] listRow =
            {
                field.FieldName, field.FieldDataType, field.FieldDataLength, field.NotNull.ToString(),
                field.AddToRequest.ToString(), field.AddToResponse.ToString(), field.HasGetMethod.ToString(),
                field.IsUnique.ToString()
            };

            return listRow;
        }

        private static string[] RefToListRow(Reference reference)
        {
            string[] listRow =
            {
                reference.FieldName, reference.FieldDataType, reference.Relation.ToString(), reference.NotNull.ToString(),
                reference.AddToRequest.ToString(), reference.AddToResponse.ToString(), reference.HasGetMethod.ToString(),
                reference.IsUnique.ToString(), reference.ReferenceClassName
            };

            return listRow;
        }

        private void ListViews_Configuration()
        {
            const int columnSize = 75;

            LstViewFields.View = View.Details;
            LstViewFields.FullRowSelect = true;

            LstViewFields.Columns.Add("Field Name", columnSize * 2); //0
            LstViewFields.Columns.Add("Data Type", columnSize); //1
            LstViewFields.Columns.Add("Field Length", columnSize); //2
            LstViewFields.Columns.Add("Not Null", columnSize); //3
            LstViewFields.Columns.Add("Add To Request", columnSize); //4
            LstViewFields.Columns.Add("Add To Response", columnSize); //5
            LstViewFields.Columns.Add("Has Get Method", columnSize); //6
            LstViewFields.Columns.Add("Is Unique", columnSize); //7

            LstViewReferences.View = View.Details;
            LstViewReferences.FullRowSelect = true;

            LstViewReferences.Columns.Add("Field Name", columnSize * 2); //0
            LstViewReferences.Columns.Add("Data Type", columnSize); //1
            LstViewReferences.Columns.Add("Rel.", columnSize); //1
            LstViewReferences.Columns.Add("Not Null", columnSize); //3
            LstViewReferences.Columns.Add("Add To Request", columnSize); //4
            LstViewReferences.Columns.Add("Add To Response", columnSize); //5
            LstViewReferences.Columns.Add("Has Get Method", columnSize); //6
            LstViewReferences.Columns.Add("Is Unique", columnSize); //7
        }

        private static Relations GetRelationByRadioButtons(bool rdOneToMany, bool rdManyToOne, bool rdOneToOne, bool rdManyToMany)
        {
            Relations relations = Relations.OneToOne;
            var countTrues = 0;

            if (rdOneToMany)
            {
                relations = Relations.OneToMany;
                countTrues++;
            }

            if (rdManyToOne)
            {
                relations = Relations.ManyToOne;
                countTrues++;
            }

            if (rdOneToOne)
            {
                relations = Relations.OneToOne;
                countTrues++;
            }

            if (rdManyToMany)
            {
                relations = Relations.ManyToMany;
                countTrues++;
            }

            if (countTrues > 1) throw new Exception("Birden fazla ilişki seçili");

            return relations;
        }

        private static async Task<bool> FileCreatorAsync(string path, string fileName, string content)
        {
            var fullPath = $"{path}\\{fileName}";

            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            using (var fs = File.Create(fullPath))
            {
                var byteContent = new UTF8Encoding(true).GetBytes(content);
                await fs.WriteAsync(byteContent, 0, byteContent.Length);
            }

            return true;
        }

        public static bool EditCodeFileAsync(string filePath, string word, string replacement)
        {
            var reader = new StreamReader(filePath);
            var input = reader.ReadToEnd();
            reader.Close();

            var newText = input.Replace(word, replacement);


            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                stream.Write(Encoding.ASCII.GetBytes(newText), 0, Encoding.ASCII.GetByteCount(newText));
                stream.Close();
            }

            return true;
        }


        #region UIMethods

        private void frmCodeGenerator_Load(object sender, EventArgs e)
        {
            CmbFieldDataTypes.DataSource = _fieldDataTypes;
            ListViews_Configuration();
            Load_Datas();
            TxtClassName.Focus();
        }

        private void BtnClass_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNameSpace.Text))
            {
                MessageBox.Show(@"You must enter a value for namespace", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(TxtProjectFolder.Text))
            {
                MessageBox.Show(@"You must enter a value for project folder path", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _nameSpace = TxtNameSpace.Text;
            _projectPath = TxtProjectFolder.Text;
            _projectName = TxtProjectName.Text;

            if (string.IsNullOrEmpty(TxtClassName.Text))
            {
                MessageBox.Show(@"You must enter a value for class name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (RdInt32.Checked == false && RdLong.Checked == false)
            {
                MessageBox.Show(@"You must select a data type for primary key", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GrpClass.Enabled = false;
            GrpField.Enabled = true;
            TxtFieldName.Focus();
        }

        private void BtnCreateField_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtFieldName.Text))
            {
                MessageBox.Show(@"You must enter a value for field name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty((string)CmbFieldDataTypes.SelectedValue))
            {
                MessageBox.Show(@"You must enter select a data type", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TxtFieldLength.Enabled && string.IsNullOrEmpty(TxtFieldLength.Text))
            {
                MessageBox.Show(@"You must enter field length value", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var field = new Field(
                fieldName: TxtFieldName.Text,
                fieldDataType: CmbFieldDataTypes.SelectedValue.ToString(),
                fieldDataLength: TxtFieldLength.Text,
                notNull: ChkNotNull.Checked,
                addToRequest: ChkAddToRequest.Checked,
                addToResponse: ChkAddToResponse.Checked,
                hasGetMethod: ChkHasGetMethod.Checked,
                isUnique: ChkIsUnique.Checked
            );

            AddToListView(field);

            TxtFieldName.Clear();
            CmbFieldDataTypes.SelectedIndex = 0;
            TxtFieldLength.Clear();
            ChkNotNull.Checked = false;
            ChkHasGetMethod.Checked = false;
            ChkAddToRequest.Checked = false;
            ChkAddToResponse.Checked = false;
            ChkIsUnique.Checked = false;

            TxtFieldName.Focus();
        }

        private void CmbFieldDataTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtFieldLength.Enabled =
                (CmbFieldDataTypes.SelectedValue != null && CmbFieldDataTypes.SelectedValue.ToString() == "string");
        }

        private void TxtFieldLength_EnabledChanged(object sender, EventArgs e)
        {
            if (TxtFieldLength.Enabled == false) TxtFieldLength.Clear();
        }

        private void ChkHasGetAllMethod_CheckedChanged(object sender, EventArgs e)
        {
            ChkGetAllWithPaging.Visible = ChkHasGetAllMethod.Checked;
        }

        private void ChkGetAllWithPaging_VisibleChanged(object sender, EventArgs e)
        {
            if (!ChkGetAllWithPaging.Visible) ChkGetAllWithPaging.Checked = false;
        }

        private void LstViewFields_DoubleClick(object sender, EventArgs e)
        {
            LstViewFields.SelectedItems[0].Remove();
        }

        private void BtnAddOneToManyRef_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtRefName.Text))
            {
                MessageBox.Show(@"You must enter a value for field name", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var relation = GetRelationByRadioButtons(RdOneToMany.Checked, RdManyToOne.Checked, RdOneToOne.Checked,
                RdManyToMany.Checked);

            var reference = new Reference(
                fieldName: TxtRefName.Text,
                fieldDataType: RdRefInt32.Checked ? "int" : "long",
                relation: relation,
                notNull: ChkRefNotNull.Checked,
                addToRequest: ChkRefAddToRequest.Checked,
                addToResponse: ChkRefAddToResponse.Checked,
                hasGetMethod: ChkRefHasGet.Checked,
                isUnique: ChkRefIsUnique.Checked,
                referenceClassName: TxtRefClassName.Text
            );

            AddRefToListView(reference);

            RdRefInt32.Checked = true;
            RdRefInt64.Checked = false;
            RdOneToMany.Checked = true;
            RdManyToOne.Checked = false;
            RdOneToOne.Checked = false;
            RdManyToMany.Checked = false;
            TxtRefName.Clear();
            TxtFieldLength.Clear();
            ChkRefNotNull.Checked = false;
            ChkRefAddToRequest.Checked = false;
            ChkRefAddToResponse.Checked = false;
            ChkRefHasGet.Checked = false;
            ChkRefIsUnique.Checked = false;
            TxtRefClassName.Clear();
            TxtFieldName.Enabled = true;
            ChkRefNotNull.Enabled = true;
            ChkRefAddToRequest.Enabled = true;
            ChkRefAddToResponse.Enabled = true;
            ChkRefHasGet.Enabled = true;
            ChkRefIsUnique.Enabled = true;
        }

        private void LstViewReferences_DoubleClick(object sender, EventArgs e)
        {
            LstViewReferences.SelectedItems[0].Remove();
        }

        private void BtnCreateFiles_Click(object sender, EventArgs e)
        {
            var className = TxtClassName.Text;

            var idFieldDataType = RdInt32.Checked ? "int" : "long";

            var mappingProfilePath = Path.Combine(_projectPath, Path.Combine("AutoMapper", "MappingProfile.cs"));
            var contextPath = Path.Combine(_projectPath, Path.Combine("Data", "ApplicationContext.cs"));
            var startupPath = Path.Combine(_projectPath, "Startup.cs");
            var iUnitOfWorkPath = Path.Combine(_projectPath, Path.Combine("Data", "IUnitOfWorkWebApi.cs"));
            var unitOfWorkPath = Path.Combine(_projectPath, Path.Combine("Data", "unitOfWorkWebApi.cs"));
            var constantPath = Path.Combine(_projectPath, Path.Combine("Constants", "WebApiResourceConstants.cs"));

            const string mappingProfileTag = "/*********End of Entities Mapping*********/";
            const string contextDbSetsTag = "/*********End of DbSets**********/";
            const string contextModelConfigurationTag = "/*************End of ModelConfigurations**********/";
            const string startupRepositoryTag = "/*********End of Repositories*********/";
            const string startupManagerTag = "/*********End of Managers*********/";
            const string startupFluentValidationTag = "/************End of Fluent Validation************/";
            const string iUnitOfWorkTag = "/*********End of Repositories*********/";
            const string unitOfWorkRepositoryTag = "/*********End of Repositories*********/";
            const string unitOfWorkInstanceTag = "/*********End of Instances*********/";
            const string constantTag = "/*********End of Constants*********/";


            Task t1 = FileCreatorAsync(
                Path.Combine(_projectPath,
                    string.IsNullOrEmpty(_projectName) ? "Models" : Path.Combine(_projectName, "Models"))
                , $"{className}.cs"
                , CreateEntityClass(className, idFieldDataType));

            Task t2 = FileCreatorAsync(
                Path.Combine(_projectPath,
                    string.IsNullOrEmpty(_projectName) ? "Data/Repositories" : Path.Combine(_projectName, "Data/Repositories"))
                , $"I{className}Repository.cs"
                , CreateRepositoryInterfaceClass(className, idFieldDataType));

            Task t3 = FileCreatorAsync(
                Path.Combine(_projectPath,
                    string.IsNullOrEmpty(_projectName) ? "Data/Repositories" : Path.Combine(_projectName, "Data/Repositories"))
                , $"{className}Repository.cs"
                , CreateRepositoryClass(className, idFieldDataType));

            Task t4 = FileCreatorAsync(
                Path.Combine(_projectPath,
                    string.IsNullOrEmpty(_projectName) ? "Requests" : Path.Combine(_projectName, "Requests"))
                , $"{className}Request.cs"
                , CreateRequestEntityClass(className));

            Task t5 = FileCreatorAsync(
                Path.Combine(_projectPath,
                    string.IsNullOrEmpty(_projectName) ? "Responses" : Path.Combine(_projectName, "Responses"))
                , $"{className}Response.cs"
                , CreateResponseEntityClass(className, idFieldDataType));

            Task t6 = FileCreatorAsync(
                Path.Combine(_projectPath,
                    string.IsNullOrEmpty(_projectName) ? "Business" : Path.Combine(_projectName, "Business"))
                , $"I{className}Manager.cs"
                , CreateBusinessInterfaceClass(className, idFieldDataType));

            Task t7 = FileCreatorAsync(
                Path.Combine(_projectPath,
                    string.IsNullOrEmpty(_projectName) ? "Business" : Path.Combine(_projectName, "Business"))
                , $"{className}Manager.cs"
                , CreateBusinessClass(className, idFieldDataType));

            Task t8 = FileCreatorAsync(
                Path.Combine(_projectPath,
                    string.IsNullOrEmpty(_projectName) ? "Validators" : Path.Combine(_projectName, "Validators"))
                , $"{className}Validator.cs"
                , CreateValidatorClass(className));

            Task t9 = FileCreatorAsync(
                Path.Combine(_projectPath,
                    string.IsNullOrEmpty(_projectName) ? "Controllers" : Path.Combine(_projectName, "Controllers"))
               , $"{className}Controller.cs"
                , CreateControllerClass(className, idFieldDataType));

            Task t10 = FileCreatorAsync(
                Path.Combine(_projectPath,
                    string.IsNullOrEmpty(_projectName) ? "Data/ModelConfigurations" : Path.Combine(_projectName, "Data/ModelConfigurations"))
                , $"{className}ModelConfiguration.cs"
                , CreateModelConfigurationClass(className, idFieldDataType));

            EditCodeFileAsync(mappingProfilePath, mappingProfileTag, CreateMappingProfile(className) + Environment.NewLine + mappingProfileTag);
            EditCodeFileAsync(contextPath, contextDbSetsTag, CreateContextDbSet(className) + Environment.NewLine + contextDbSetsTag);
            EditCodeFileAsync(contextPath, contextModelConfigurationTag, CreateContextModelConfiguration(className) + Environment.NewLine + contextModelConfigurationTag);
            EditCodeFileAsync(startupPath, startupRepositoryTag,
                CreateStartupRepository(className) + Environment.NewLine + startupRepositoryTag);
            EditCodeFileAsync(startupPath, startupManagerTag,
                CreateStartupManager(className) + Environment.NewLine + startupManagerTag);
            EditCodeFileAsync(startupPath, startupFluentValidationTag,
                CreateStartupValidator(className) + Environment.NewLine + startupFluentValidationTag);
            EditCodeFileAsync(iUnitOfWorkPath, iUnitOfWorkTag,
                CreateIUnitOfWork(className) + Environment.NewLine + iUnitOfWorkTag);
            EditCodeFileAsync(unitOfWorkPath, unitOfWorkRepositoryTag,
                CreateUnitOfWorkRepository(className) + Environment.NewLine + unitOfWorkRepositoryTag);
            EditCodeFileAsync(unitOfWorkPath, unitOfWorkInstanceTag,
                CreateUnitOfWorkInstance(className) + Environment.NewLine + unitOfWorkInstanceTag);
            EditCodeFileAsync(constantPath, constantTag,
                CreateConstant() + Environment.NewLine + constantTag);

            Task.Factory.StartNew(() => t1);
            Task.Factory.StartNew(() => t2);
            Task.Factory.StartNew(() => t3);
            Task.Factory.StartNew(() => t4);
            Task.Factory.StartNew(() => t5);
            Task.Factory.StartNew(() => t6);
            Task.Factory.StartNew(() => t7);
            Task.Factory.StartNew(() => t8);
            Task.Factory.StartNew(() => t9);
            Task.Factory.StartNew(() => t10);

            Task.WaitAll();
            LblStatus.Text = @"Tamamlandı";
        }

        #endregion

        #region Functions

        private static string GetFieldString()
        {
            return "public {fieldDataType} {fieldName} { get; set; }";
        }

        private static string GetReferenceFieldString()
        {
            return "public virtual {referenceClassName} {referenceClassName} { get; set; }";
        }

        private static string GetReferenceListFieldString()
        {
            return "public virtual ICollection<{referenceClassName}> {referenceClassNamePlural} { get; set; }";
        }

        private static string GetRequestReferenceFieldString()
        {
            return "public virtual {referenceClassName}Request {referenceClassName} { get; set; }";
        }

        private static string GetRequestReferenceListFieldString()
        {
            return "public virtual ICollection<{referenceClassName}Request> {referenceClassNamePlural} { get; set; }";
        }

        private static string GetResponseReferenceFieldString()
        {
            return "public virtual {referenceClassName}Response {referenceClassName} { get; set; }";
        }

        private static string GetResponseReferenceListFieldString()
        {
            return "public virtual ICollection<{referenceClassName}Response> {referenceClassNamePlural} { get; set; }";
        }

        #endregion

        #region Class Generator
        private string CreateEntityClass(string className, string idFieldDataType)
        {
            var value =
@"using System.Collections.Generic;
using CustomFramework.Data;

namespace {nameSpace}{projectName}.Models
{
    public class {className} : BaseModel<{idFieldDataType}>
    {
{fields}
{referenceTypes}
    }
}
";
            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{projectName}", string.IsNullOrEmpty(_projectName) ? string.Empty : $".{_projectName}");

            value = value.Replace("{className}", className);
            value = value.Replace("{idFieldDataType}", idFieldDataType);

            var fields = string.Empty;
            var referenceTypes = string.Empty;

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();

                fields = fields + "\t" + GetFieldString() + Environment.NewLine;

                fields = fields.Replace("{fieldDataType}", field.FieldDataType == "enum" ? field.FieldName : field.FieldDataType);

                fields = fields.Replace("{fieldName}", field.FieldName);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                if (reference.Relation == Relations.ManyToOne || reference.Relation == Relations.OneToOne)
                {
                    fields = fields + "\t" + GetFieldString() + Environment.NewLine;
                }

                fields = fields.Replace("{fieldDataType}", reference.FieldDataType);
                fields = fields.Replace("{fieldName}", reference.FieldName);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                if (reference.Relation == Relations.OneToMany || reference.Relation == Relations.ManyToMany)
                {
                    referenceTypes = referenceTypes + "\t" + GetReferenceListFieldString() + Environment.NewLine;
                }
                else
                {
                    referenceTypes = referenceTypes + "\t" + GetReferenceFieldString() + Environment.NewLine;
                }

                referenceTypes = referenceTypes.Replace("{referenceClassName}", reference.ReferenceClassName);
                referenceTypes = referenceTypes.Replace("{referenceClassNamePlural}", reference.ReferenceClassName.ToPlural());
            }

            value = value.Replace("{fields}", fields);
            value = value.Replace("{referenceTypes}", referenceTypes);


            return value;
        }

        private string CreateRequestEntityClass(string className)
        {
            var value =
@"{list}
namespace {nameSpace}{projectName}.Requests
{
    public class {className}Request
    {
{fields}
    }
}
";
            value = value.Replace("{className}", className);

            var list = string.Empty;
            var fields = string.Empty;

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();

                if (!field.AddToRequest) continue;

                fields = fields + "\t" + GetFieldString() + Environment.NewLine;

                fields = fields.Replace("{fieldDataType}", field.FieldDataType == "enum" ? field.FieldName : field.FieldDataType);
                fields = fields.Replace("{fieldName}", field.FieldName);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                if (!reference.AddToRequest) continue;

                if (reference.Relation == Relations.ManyToOne || reference.Relation == Relations.OneToOne)
                {
                    fields = fields + "\t" + GetFieldString() + Environment.NewLine;
                }

                fields = fields.Replace("{fieldDataType}", reference.FieldDataType);
                fields = fields.Replace("{fieldName}", reference.FieldName);
            }

            value = value.Replace("{list}", list);
            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{projectName}", string.IsNullOrEmpty(_projectName) ? string.Empty : $".{_projectName}");
            value = value.Replace("{fields}", fields);

            return value;
        }

        private string CreateResponseEntityClass(string className, string idFieldDataType)
        {
            var value =
@"{list}

namespace {nameSpace}{projectName}.Responses
{
    public class {className}Response
    {
        public {idFieldDataType} Id { get; set; }  
{fields}
{referenceTypes}
    }
}
";
            var list = string.Empty;
            var addList = false;
            value = value.Replace("{idFieldDataType}", idFieldDataType);
            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{projectName}", string.IsNullOrEmpty(_projectName) ? string.Empty : $".{_projectName}");
            value = value.Replace("{className}", className);

            var fields = string.Empty;
            var referenceTypes = string.Empty;

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();

                if (!field.AddToResponse) continue;

                fields = fields + "\t" + GetFieldString() + Environment.NewLine;

                fields = fields.Replace("{fieldDataType}", field.FieldDataType == "enum" ? field.FieldName : field.FieldDataType);
                fields = fields.Replace("{fieldName}", field.FieldName);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                if (!reference.AddToResponse) continue;

                if (reference.Relation == Relations.ManyToOne || reference.Relation == Relations.OneToOne)
                {
                    fields = fields + "\t" + GetFieldString() + Environment.NewLine;
                }

                fields = fields.Replace("{fieldDataType}", reference.FieldDataType);
                fields = fields.Replace("{fieldName}", reference.FieldName);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                if (!reference.AddToResponse) continue;

                if (reference.Relation == Relations.OneToMany || reference.Relation == Relations.ManyToMany)
                {
                    referenceTypes = referenceTypes + "\t" + GetResponseReferenceListFieldString() + Environment.NewLine;
                    addList = true;
                }
                else
                {
                    referenceTypes = referenceTypes + "\t" + GetResponseReferenceFieldString() + Environment.NewLine;
                }

                referenceTypes = referenceTypes.Replace("{referenceClassName}", reference.ReferenceClassName);
                referenceTypes =
                    referenceTypes.Replace("{referenceClassNamePlural}", reference.ReferenceClassName.ToPlural());
            }

            if (addList)
            {
                list = @"using System.Collections.Generic;";
            }

            value = value.Replace("{list}", list);

            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{fields}", fields);
            value = value.Replace("{referenceTypes}", referenceTypes);


            return value;
        }

        private string CreateRepositoryInterfaceClass(string className, string idFieldDataType)
        {
            var value =
@"using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;

namespace {nameSpace}{projectName}.Data.Repositories
{
    public interface I{className}Repository : IRepository<{className}, {idFieldDataType}>
    {
{methods}
    }
}";

            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{projectName}", string.IsNullOrEmpty(_projectName) ? string.Empty : $".{_projectName}");

            var methods = string.Empty;

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();

                methods = CreateRepositoryInterfaceMethod(methods, field.HasGetMethod, field.IsUnique, field.FieldName, field.FieldDataType);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                methods = CreateRepositoryInterfaceMethod(methods, reference.HasGetMethod, reference.IsUnique, reference.FieldName, reference.FieldDataType);
            }

            if (ChkHasGetAllMethod.Checked)
            {
                methods +=
                    "\t" +
                    @"Task<ICustomList<{className}>> GetAllAsync();" + Environment.NewLine;
            }

            if (ChkGetAllWithPaging.Checked)
            {
                methods +=
                    "\t" +
                    @"Task<ICustomList<{className}>> GetAllAsync(int pageIndex, int pageCount);" + Environment.NewLine;
            }

            value = value.Replace("{methods}", methods);
            value = value.Replace("{className}", className);
            value = value.Replace("{idFieldDataType}", idFieldDataType);

            return value;
        }

        private string CreateRepositoryClass(string className, string idFieldDataType)
        {
            var value =
@"using System.Threading.Tasks;
using CustomFramework.Data;
using CustomFramework.Data.Contracts;
using CustomFramework.Data.Utils;
using Microsoft.EntityFrameworkCore;

namespace {nameSpace}{projectName}.Data.Repositories
{
    public class {className}Repository : BaseRepository<{className}, {idFieldDataType}>, I{className}Repository
    {
        public {className}Repository(DbContext dbContext) : base(dbContext)
        {

        }

{methods}
    }
}";

            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{projectName}", string.IsNullOrEmpty(_projectName) ? string.Empty : $".{_projectName}");

            var methods = string.Empty;

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();

                methods = CreateRepositoryMethod(methods, field.HasGetMethod, field.IsUnique, field.FieldName, field.FieldDataType);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                methods = CreateRepositoryMethod(methods, reference.HasGetMethod, reference.IsUnique, reference.FieldName, reference.FieldDataType);
            }

            if (ChkHasGetAllMethod.Checked)
            {
                methods +=
                    "\t" +
                    @"public async Task<ICustomList<{className}>> GetAllAsync()
                        {
                            return await GetAll(){include}.ToCustomList();
                        }" + Environment.NewLine;
            }

            if (ChkGetAllWithPaging.Checked)
            {
                methods +=
                    "\t" +
                    @"public async Task<ICustomList<{className}>> GetAllAsync(int pageIndex, int pageSize)
                        {
                            return await (await GetAllWithPagingAsync(paging: new Paging(pageIndex, pageSize))){include}.ToCustomList();
                        }" + Environment.NewLine;
            }

            var includeString = string.Empty;

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                if (string.IsNullOrEmpty(includeString)) includeString = ".IncludeMultiple(";

                var reference = item.ToReference();

                if (reference.Relation == Relations.OneToMany || reference.Relation == Relations.ManyToMany)
                {
                    includeString += "p=>p.{referenceClassNamePlural},";
                }
                else
                {
                    includeString += "p=>p.{referenceClassName},";
                }

                includeString = includeString.Replace("{referenceClassName}", reference.ReferenceClassName);
                includeString = includeString.Replace("{referenceClassNamePlural}", reference.ReferenceClassName.ToPlural());
            }

            if (!string.IsNullOrEmpty(includeString))
            {
                includeString = includeString.Remove(includeString.Length - 1, 1);
                includeString += ")";
            }


            methods = methods.Replace("{include}", includeString);

            value = value.Replace("{methods}", methods);
            value = value.Replace("{className}", className);
            value = value.Replace("{idFieldDataType}", idFieldDataType);

            return value;
        }

        private string CreateBusinessInterfaceClass(string className, string idFieldDataType)
        {
            var value =
@"using System.Threading.Tasks;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;

namespace {nameSpace}{projectName}.Business
{
    public interface I{className}Manager :  IBusinessManager<{className}, {className}Request, {idFieldDataType}>
        {update}
    {
{methods}
    }
}";

            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{projectName}", string.IsNullOrEmpty(_projectName) ? string.Empty : $".{_projectName}");

            var update = string.Empty;

            if (ChkHasUpdateMethod.Checked)
            {
                update = @", IBusinessManagerUpdate<{className}, {className}Request, {idFieldDataType}>";
            }

            value = value.Replace("{update}", update);

            var methods = string.Empty;

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();

                methods = CreateBusinessInterfaceMethod(methods, field.HasGetMethod, field.IsUnique, field.FieldName,
                    field.FieldDataType);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                methods = CreateBusinessInterfaceMethod(methods, reference.HasGetMethod, reference.IsUnique, reference.FieldName, reference.FieldDataType);
            }

            if (ChkHasGetAllMethod.Checked)
            {
                methods +=
                    "\t" +
                    @"Task<ICustomList<{className}>> GetAllAsync();" + Environment.NewLine;
            }

            if (ChkGetAllWithPaging.Checked)
            {
                methods +=
                    "\t" +
                    @"Task<ICustomList<{className}>> GetAllAsync(int pageIndex, int pageCount);" + Environment.NewLine;
            }

            value = value.Replace("{methods}", methods);
            value = value.Replace("{className}", className);
            value = value.Replace("{idFieldDataType}", idFieldDataType);

            return value;
        }

        private string CreateBusinessClass(string className, string idFieldDataType)
        {
            var value =
@"using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Data.Contracts;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;

namespace {nameSpace}{projectName}.Business
{
    public class {className}Manager : BaseBusinessManagerWithApiRequest<ApiRequest>, I{className}Manager
    {
        private readonly IUnitOfWorkWebApi _uow;

        public {className}Manager(IUnitOfWorkWebApi uow, ILogger<{className}Manager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<{className}> CreateAsync({className}Request request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<{className}>(request);

                {createUnique}

                _uow.{classNamePlural}.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

{update}

        public Task DeleteAsync({idFieldDataType} id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.{classNamePlural}.Delete(result, GetLoggedInUserId());

                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<{className}> GetByIdAsync({idFieldDataType} id)
        {
            return CommonOperationAsync(async () => await _uow.{classNamePlural}.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

{methods}
    }
}";

            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{projectName}", string.IsNullOrEmpty(_projectName) ? string.Empty : $".{_projectName}");

            var methods = string.Empty;
            var createUnique = string.Empty;
            var update = string.Empty;
            var updateUnique = string.Empty;

            if (ChkHasUpdateMethod.Checked)
            {
                update +=
    "\t" +
    @"  public Task<{className}> UpdateAsync(int id, {className}Request request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                {updateUnique}

                _uow.{classNamePlural}.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }
" + Environment.NewLine;

            }

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();

                methods = CreateBusinessMethod(methods, ref createUnique, ref updateUnique, field.HasGetMethod,
                    field.IsUnique, field.FieldName, field.FieldDataType);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                methods = CreateBusinessMethod(methods, ref createUnique, ref updateUnique, reference.HasGetMethod,
                    reference.IsUnique, reference.FieldName, reference.FieldDataType);
            }

            if (ChkHasGetAllMethod.Checked)
            {
                methods +=
                    "\t" +
                    @"public Task<ICustomList<{className}>> GetAllAsync()
                        {
                            return CommonOperationAsync(async () => await _uow.{classNamePlural}.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
                        }" + Environment.NewLine;
            }

            if (ChkGetAllWithPaging.Checked)
            {
                methods +=
                    "\t" +
                    @"public Task<ICustomList<{className}>> GetAllAsync(int pageIndex, int pageSize)
                        {
                            return CommonOperationAsync(async () => await _uow.{classNamePlural}.GetAllAsync(pageIndex, pageSize), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
                        }" + Environment.NewLine;
            }

            value = value.Replace("{update}", update);
            value = value.Replace("{createUnique}", createUnique);
            value = value.Replace("{updateUnique}", updateUnique);
            value = value.Replace("{methods}", methods);
            value = value.Replace("{className}", className);
            value = value.Replace("{classNamePlural}", className.ToPlural());
            value = value.Replace("{idFieldDataType}", idFieldDataType);

            return value;
        }

        private string CreateValidatorClass(string className)
        {
            var value =
@"using CustomFramework.WebApiUtils.Constants;
using FluentValidation;

namespace {nameSpace}{projectName}.Validators
{
    public class {className}Validator : AbstractValidator<{className}Request>
    {
        public {className}Validator()
        {
{rules}
        }
    }
}
";
            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{projectName}", string.IsNullOrEmpty(_projectName) ? string.Empty : $".{_projectName}");

            value = value.Replace("{className}", className);

            var rules = string.Empty;

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();

                rules = CreateValidatorProperty(rules, field.NotNull, field.FieldName, field.FieldDataType,
                    field.FieldDataLength);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                rules = CreateValidatorProperty(rules, reference.NotNull, reference.FieldName, reference.FieldDataType, _projectName);
            }

            value = value.Replace("{rules}", rules);
            value = value.Replace("'", "\"");


            return value;
        }

        private string CreateControllerClass(string className, string idFieldDataType)
        {
            var value =
@"using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.Authorization.Attributes;
using CustomFramework.Authorization.Enums;
using CustomFramework.WebApiUtils.Authorization.Controllers;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace {nameSpace}{projectName}.Controllers
{
    [Route(ApiConstants.DefaultRoute + {projectNameRoute} nameof({className}))]
    public class {className}Controller : {baseController}
    {

        public {className}Controller(I{className}Manager {classNameToLower}Manager, ILocalizationService localizationService, ILogger<{className}Controller> logger, IMapper mapper)
        : base({classNameToLower}Manager, localizationService, logger, mapper)
        {

        }

        [Route('create')]
        [HttpPost]
        [Permission(nameof({className}), Crud.Create)]
        public async Task<IActionResult> Create([FromBody] {className}Request request)
        {
                return await BaseCreate(request);
        }

        {update}

        [Route('delete/{id:{idFieldDataType}}')]
        [HttpDelete]
        [Permission(nameof({className}), Crud.Delete)]
        public async Task<IActionResult> Delete({idFieldDataType} id)
        {
            return await BaseDelete(id);
        }

        [Route('get/id/{id:{idFieldDataType}}')]
        [HttpGet]
        [Permission(nameof({className}), Crud.Select)]
        public async Task<IActionResult> GetById({idFieldDataType} id)
        {
            return await BaseGetById(id);
        }

{methods}
    }
}";

            var methods = string.Empty;
            var update = string.Empty;

            if (ChkHasUpdateMethod.Checked)
            {
                value = value.Replace("{baseController}", "BaseControllerWithCrudAuthorization<{className}, {className}Request, {className}Request, {className}Response, I{className}Manager, {idFieldDataType}>");

                update +=
    "\t" +
    @"[Route('{id:{idFieldDataType}}/update')]
      [HttpPut]
      [Permission(nameof({className}), Crud.Update)]
      public async Task<IActionResult> Update(int id, [FromBody] {className}Request request)
      {
            return await BaseUpdate(id, request);
      }" + Environment.NewLine;

            }
            else
            {
                value = value.Replace("{baseController}", "BaseControllerWithCrdAuthorization<{className}, {className}Request, {className}Response, I{className}Manager, {idFieldDataType}>");
            }

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();
                methods = CreateControllerMethod(methods, field.HasGetMethod, field.IsUnique, field.FieldName,
                    field.FieldDataType);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();
                methods = CreateControllerMethod(methods, reference.HasGetMethod, reference.IsUnique, reference.FieldName,
                    reference.FieldDataType);
            }

            if (ChkHasGetAllMethod.Checked)
            {
                methods +=
                    "\t" +
                    @"[Route('getall')]
                    [HttpGet]
                    [Permission(nameof({className}), Crud.Select)]
                    public async Task<IActionResult> GetAll()
                    {
                        var result = await Manager.GetAllAsync();
                        return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                            Mapper.Map<IEnumerable<{className}>, IEnumerable<{className}Response>>(result.ResultList),result.Count));
                    }" + Environment.NewLine;
            }

            if (ChkGetAllWithPaging.Checked)
            {
                methods +=
                    "\t" +
                    @"[Route('getall/pageindex/{pageIndex:int}/pagesize/{pageSize:int}')]
                    [HttpGet]
                    [Permission(nameof({className}), Crud.Select)]
                    public async Task<IActionResult> GetAll(int pageIndex, int pageSize)
                    {
                        var result = await Manager.GetAllAsync(pageIndex, pageSize);
                        return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                            Mapper.Map<IList<{className}>, IList<{className}Response>>(result.ResultList.ToList()), result.Count));
                    }" + Environment.NewLine;
            }

            value = value.Replace("{update}", update);
            value = value.Replace("{methods}", methods);
            value = value.Replace("{className}", className);
            value = value.Replace("{classNameToLower}", className.ToLower());
            value = value.Replace("{classNamePlural}", className.ToPlural());
            value = value.Replace("{idFieldDataType}", idFieldDataType);
            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{projectName}", string.IsNullOrEmpty(_projectName) ? string.Empty : $".{_projectName}");
            value = value.Replace("{projectNameRoute}", string.IsNullOrEmpty(_projectName) ? string.Empty : "ApiConstants.AtsProjectRoute +");

            value = value.Replace("'", "\"");

            return value;
        }

        private string CreateModelConfigurationClass(string className, string idFieldDataType)
        {
            var value =
@"using System.Collections.Generic;
using CustomFramework.Data.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace {nameSpace}{projectName}.Data.ModelConfigurations
{
    public class {className}ModelConfiguration<T> : BaseModelConfiguration<T, {idFieldDataType}> where T : {className}
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            {property}

            {reference}

            {index}
        }
    }
}";
            var property = string.Empty;
            var references = string.Empty;
            var index = string.Empty;

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();
                property = CreateModelConfigurationPropertyMethod(property, field.NotNull, field.FieldDataLength,
                    field.FieldName);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                if (reference.Relation == Relations.ManyToOne || reference.Relation == Relations.OneToOne)
                    property = CreateModelConfigurationPropertyMethod(property, reference.NotNull, string.Empty, reference.FieldName);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();
                references = CreateModelConfigurationReferenceMethod(references, reference.Relation, className,
                    reference.ReferenceClassName, reference.NotNull, reference.FieldName);
            }

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();
                index = CreateModelConfigurationIndexMethod(index, field.IsUnique, field.FieldName);
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();
                index = CreateModelConfigurationIndexMethod(index, reference.IsUnique, reference.FieldName);
            }

            value = value.Replace("{property}", property);
            value = value.Replace("{reference}", references);
            value = value.Replace("{index}", index);
            value = value.Replace("{idFieldDataType}", idFieldDataType);
            value = value.Replace("{className}", className);
            value = value.Replace("{nameSpace}", _nameSpace);
            value = value.Replace("{projectName}", string.IsNullOrEmpty(_projectName) ? string.Empty : $".{_projectName}");

            return value;
        }

        #endregion

        #region Method Generator

        private static string CreateRepositoryInterfaceMethod(string methods, bool hasGetMethod, bool isUnique, string fieldName, string fieldDataType)
        {
            if (!hasGetMethod) return methods;

            if (isUnique)
            {
                methods +=
                    "\t" +
                    @"Task<{className}> GetBy{fieldName}Async({fieldDataType} {fieldNameToLower});" + Environment.NewLine;
            }
            else
            {
                methods +=
                    "\t" +
                    @"Task<ICustomList<{className}>> GetAllBy{fieldName}Async({fieldDataType} {fieldNameToLower});" + Environment.NewLine;
            }


            methods = methods.Replace("{fieldName}", fieldName);
            methods = methods.Replace("{fieldNameToLower}", fieldName.ToLowerFirstLetter());
            methods = methods.Replace("{fieldDataType}", fieldDataType == "enum" ? fieldName : fieldDataType);

            return methods;
        }

        private static string CreateRepositoryMethod(string methods, bool hasGetMethod, bool isUnique, string fieldName,
    string fieldDataType)
        {
            if (!hasGetMethod) return methods;

            if (isUnique)
            {
                methods +=
                    "\t" +
                    @"public async Task<{className}> GetBy{fieldName}Async({fieldDataType} {fieldNameToLower})
                        {
                            return await Get(p => p.{fieldName} == {fieldNameToLower}){include}.FirstOrDefaultAsync();
                        }" + Environment.NewLine;
            }
            else
            {
                methods +=
                    "\t" +
                    @"public async Task<ICustomList<{className}>> GetAllBy{fieldName}Async({fieldDataType} {fieldNameToLower})
                        {
                            return await GetAll(predicate: p => p.{fieldName} == {fieldNameToLower}){include}.ToCustomList();
                        }" + Environment.NewLine;
            }

            methods = methods.Replace("{fieldName}", fieldName);
            methods = methods.Replace("{fieldNameToLower}", fieldName.ToLowerFirstLetter());
            methods = methods.Replace("{fieldDataType}", fieldDataType == "enum" ? fieldName : fieldDataType);

            return methods;
        }

        private static string CreateBusinessInterfaceMethod(string methods, bool hasGetMethod, bool isUnique, string fieldName, string fieldDataType)
        {
            if (!hasGetMethod) return methods;

            if (isUnique)
            {
                methods +=
                    "\t" +
                    @"Task<{className}> GetBy{fieldName}Async({fieldDataType} {fieldNameToLower});" + Environment.NewLine;
            }
            else
            {
                methods +=
                    "\t" +
                    @"Task<ICustomList<{className}>> GetAllBy{fieldName}Async({fieldDataType} {fieldNameToLower});" + Environment.NewLine;
            }

            methods = methods.Replace("{fieldName}", fieldName);
            methods = methods.Replace("{fieldNameToLower}", fieldName.ToLowerFirstLetter());
            methods = methods.Replace("{fieldDataType}", fieldDataType == "enum" ? fieldName : fieldDataType);

            return methods;
        }

        private static string CreateBusinessMethod(string methods, ref string createUnique, ref string updateUnique, bool hasGetMethod, bool isUnique, string fieldName, string fieldDataType)
        {
            if (hasGetMethod)
            {
                if (isUnique)
                {
                    methods +=
                        "\t" +
                        @"public Task<{className}> GetBy{fieldName}Async({fieldDataType} {fieldNameToLower})
                        {
            return CommonOperationAsync(async () => await _uow.{classNamePlural}.GetBy{fieldName}Async({fieldNameToLower}), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);                        
                        }" + Environment.NewLine;
                }
                else
                {
                    methods +=
"\t" +
@"public Task<ICustomList<{className}>> GetAllBy{fieldName}Async({fieldDataType} {fieldNameToLower})
                        {
            return CommonOperationAsync(async () => await _uow.{classNamePlural}.GetAllBy{fieldName}Async({fieldNameToLower}), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
                        }" + Environment.NewLine;
                }
            }

            if (isUnique)
            {
                createUnique +=
                    "\t" +
                    @"/******************{fieldName} is unique*********************/
                /*****************************************************/
                var {fieldNameToLower}UniqueResult = await _uow.{classNamePlural}.GetBy{fieldName}Async(request.{fieldName});

                {fieldNameToLower}UniqueResult.CheckUniqueValue(WebApiResourceConstants.{fieldName});
                /*****************************************************/
                /******************{fieldName} is unique*********************/" + Environment.NewLine;

                updateUnique +=
"\t" +
@"/******************{fieldName} is unique*********************/
                /*****************************************************/
                var {fieldNameToLower}UniqueResult = await _uow.{classNamePlural}.GetBy{fieldName}Async(request.{fieldName});

                {fieldNameToLower}UniqueResult.CheckUniqueValueForUpdate(result.Id, WebApiResourceConstants.{fieldName});
                /*****************************************************/
                /******************{fieldName} is unique*********************/" + Environment.NewLine;

            }

            createUnique = createUnique.Replace("{fieldName}", fieldName);
            updateUnique = updateUnique.Replace("{fieldName}", fieldName);

            createUnique = createUnique.Replace("{fieldNameToLower}", fieldName.ToLowerFirstLetter());
            updateUnique = updateUnique.Replace("{fieldNameToLower}", fieldName.ToLowerFirstLetter());

            methods = methods.Replace("{fieldName}", fieldName);
            methods = methods.Replace("{fieldNameToLower}", fieldName.ToLowerFirstLetter());
            methods = methods.Replace("{fieldDataType}", fieldDataType == "enum" ? fieldName : fieldDataType);

            return methods;
        }

        private static string CreateValidatorProperty(string rules, bool notNull, string fieldName, string fieldDataType, string projectName, string fieldDataLength = "")
        {
            if (!notNull && fieldDataType != "string") return rules;

            var empty = string.Empty;
            var maxLength = string.Empty;

            rules = rules + "\t" + @"
                RuleFor(x => x.{fieldName}){empty}{maxlength};" + Environment.NewLine;

            var constant = string.IsNullOrEmpty(projectName) ? "WebApiResourceConstants" : $"{projectName}ResourceConstants";

            if (notNull)
            {
                empty =
                    @".NotEmpty().WithMessage($'{ValidatorConstants.CannotBeNullError} : {{constant}.{fieldName}}')";
            }

            if (fieldDataType.ToLower() == typeof(string).Name.ToLower())
            {
                maxLength =
                    @".MaximumLength({fieldMaxLength}).WithMessage($'{ValidatorConstants.MaxLengthError} : {{constant}.{fieldName}}, {fieldMaxLength}')";
            }

            rules = rules.Replace("{fieldName}", fieldName);
            rules = rules.Replace("{fieldMaxLength}", fieldDataLength);
            rules = rules.Replace("{constant}", constant);

            rules = rules.Replace("{empty}", empty);
            rules = rules.Replace("{maxlength}", maxLength);

            return rules;
        }


        private static string CreateControllerMethod(string methods, bool hasGetMethod, bool isUnique, string fieldName, string fieldDataType)
        {
            if (hasGetMethod)
            {
                if (isUnique)
                {
                    methods +=
                        "\t" +
                        @"[Route('get/{fieldNameToLower}/{{fieldNameToLower}{fieldDataTypeController}}')]
                            [HttpGet]
                            [Permission(nameof({className}), Crud.Select)]
                            public async Task<IActionResult> GetBy{fieldName}({fieldDataType} {fieldNameToLower})
                            {
                                var result = await Manager.GetBy{fieldName}Async({fieldNameToLower});
                                return Ok(new ApiResponse(LocalizationService, Logger).Ok(Mapper.Map<{className}, {className}Response>(result)));
                            }" + Environment.NewLine;
                }
                else
                {
                    methods +=
                        "\t" +
                        @"[Route('getall/{fieldNameToLower}/{{fieldNameToLower}{fieldDataTypeController}}')]
                            [HttpGet]
                            [Permission(nameof({className}), Crud.Select)]
                            public async Task<IActionResult> GetAllBy{fieldName}({fieldDataType} {fieldNameToLower})
                            {
                                var result = await Manager.GetAllBy{fieldName}Async({fieldNameToLower});
                                return Ok(new ApiResponse(LocalizationService, Logger).Ok(
                                    Mapper.Map<IList<{className}>, IList<{className}Response>>(result.ResultList), result.Count));
                            }" + Environment.NewLine;
                }
            }

            if (fieldDataType == "int" || fieldDataType == "long")
                methods = methods.Replace("{fieldDataTypeController}", ":{fieldDataType}");
            else
                methods = methods.Replace("{fieldDataTypeController}", string.Empty);

            if (fieldDataType == "enum")
                methods = methods.Replace("{fieldDataType}", "{fieldName}");

            methods = methods.Replace("{fieldName}", fieldName);
            methods = methods.Replace("{fieldNameToLower}", fieldName.ToLowerFirstLetter());
            methods = methods.Replace("{fieldDataType}", fieldDataType);

            return methods;
        }


        private static string CreateModelConfigurationPropertyMethod(string property, bool isRequired, string maxLength, string fieldName)
        {
            property +=
                "\t" +
                @"builder.Property(p => p.{fieldName}){required}{maxLength};" + Environment.NewLine;

            property = property.Replace("{required}", isRequired ? @".IsRequired()" : string.Empty);
            property = property.Replace("{maxLength}", string.IsNullOrEmpty(maxLength) == false ? $".HasMaxLength({maxLength})" : string.Empty);


            property = property.Replace("{fieldName}", fieldName);

            return property;
        }

        private static string CreateModelConfigurationReferenceMethod(string reference, Relations relation, string className, string referenceClassName, bool isRequired, string fieldName)
        {
            switch (relation)
            {
                case Relations.OneToOne:
                    reference +=
                        "\t" +
                        @"builder.HasOne(r => r.{referenceClassName}).WithOne(c => (T)c.{className}).HasForeignKey<{className}>(r => r.{fieldName}).HasPrincipalKey<{referenceClassName}>(c => c.Id){required};" +
                        Environment.NewLine;
                    break;
                case Relations.ManyToOne:
                    reference +=
                        "\t" +
                        @"builder.HasOne(r => r.{referenceClassName}).WithMany(c => (IEnumerable<T>)c.{classNameToPlural}).HasForeignKey(r => r.{fieldName}).HasPrincipalKey(c => c.Id){required};" +
                        Environment.NewLine;
                    break;
                case Relations.OneToMany:
                case Relations.ManyToMany:
                    //    reference +=
                    //        "\t" +
                    //        @"builder.HasOne(r => r.{oneReference}).WithMany(c => (IEnumerable<T>)c.{classNamePlural}).HasForeignKey(r => r.{fieldName}).HasPrincipalKey(c => c.Id){required};" +
                    //        Environment.NewLine;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(relation), relation, null);
            }

            reference = reference.Replace("{required}", isRequired ? @".IsRequired()" : string.Empty);
            reference = reference.Replace("{referenceClassName}", referenceClassName);
            reference = reference.Replace("{className}", className);
            reference = reference.Replace("{classNameToPlural}", className.ToPlural());
            reference = reference.Replace("{fieldName}", fieldName);

            return reference;
        }

        private static string CreateModelConfigurationIndexMethod(string index, bool isUnique, string fieldName)
        {
            if (!isUnique) return index;

            index +=
                "\t" +
                @"builder.HasIndex(p => p.{fieldName}).IsUnique();" + Environment.NewLine;

            index = index.Replace("{fieldName}", fieldName);

            return index;
        }

        #endregion

        #region PartialCodes

        private static string CreateMappingProfile(string className)
        {
            var value =
@"CreateMap<{className}, {className}Response>();
CreateMap<{className}Request, {className}>();";
            value = value.Replace("{className}", className);
            return value;
        }

        private static string CreateContextDbSet(string className)
        {
            var value =
@"public virtual DbSet<{className}> {classNameToPlural} { get; set; }";
            value = value.Replace("{className}", className);
            value = value.Replace("{classNameToPlural}", className.ToPlural());
            return value;
        }

        private static string CreateContextModelConfiguration(string className)
        {
            var value =
@"modelBuilder.ApplyConfiguration(new {className}ModelConfiguration<{className}>());";
            value = value.Replace("{className}", className);
            return value;
        }

        private static string CreateStartupRepository(string className)
        {
            var value =
@"services.AddTransient<I{className}Repository, {className}Repository>();";
            value = value.Replace("{className}", className);
            return value;
        }

        private static string CreateStartupManager(string className)
        {
            var value =
@"services.AddTransient<I{className}Manager, {className}Manager>();";
            value = value.Replace("{className}", className);
            return value;
        }

        private static string CreateStartupValidator(string className)
        {
            var value =
@"services.AddTransient<IValidator<{className}Request>, {className}Validator>();";
            value = value.Replace("{className}", className);
            return value;
        }

        private static string CreateIUnitOfWork(string className)
        {
            var value =
@"I{className}Repository {classNameToPlural} { get; }";
            value = value.Replace("{className}", className);
            value = value.Replace("{classNameToPlural}", className.ToPlural());

            return value;
        }

        private static string CreateUnitOfWorkInstance(string className)
        {
            var value =
                @"{classNameToPlural} = new {className}Repository(context);";
            value = value.Replace("{className}", className);
            value = value.Replace("{classNameToPlural}", className.ToPlural());
            return value;
        }

        private static string CreateUnitOfWorkRepository(string className)
        {
            var value =
@"public I{className}Repository {classNameToPlural} { get; }";
            value = value.Replace("{className}", className);
            value = value.Replace("{classNameToPlural}", className.ToPlural());
            return value;
        }

        private string CreateConstant()
        {
            var value = string.Empty;

            var constantPath = Path.Combine(_projectPath,
                string.IsNullOrEmpty(_projectName)
                    ? Path.Combine("Constants", "WebApiResourceConstants.cs")
                    : Path.Combine(_projectName, Path.Combine("Constants", $"{_projectName}ResourceConstants.cs")));

            foreach (ListViewItem item in LstViewFields.Items)
            {
                var field = item.ToField();

                var stringText = @"public const string {fieldName} = '{fieldName}';".Replace("{fieldName}", field.FieldName).Replace("'", "\"");

                var reader = new StreamReader(constantPath);
                var input = reader.ReadToEnd();
                reader.Close();

                if (!input.Contains(stringText))
                    value += stringText + Environment.NewLine;
            }

            foreach (ListViewItem item in LstViewReferences.Items)
            {
                var reference = item.ToReference();

                if (!reference.NotNull && reference.FieldDataType != "string") continue; //Validator sınıfı ancak bu şartlar sağlandığında ekliyor

                var stringText = @"public const string {fieldName} = '{fieldName}';".Replace("{fieldName}", reference.FieldName).Replace("'", "\"");

                var reader = new StreamReader(constantPath);
                var input = reader.ReadToEnd();
                reader.Close();

                if (!input.Contains(stringText))
                    value += stringText + Environment.NewLine;
            }

            return value;
        }


        #endregion

        private void RdManyToMany_CheckedChanged(object sender, EventArgs e)
        {
            if (RdManyToMany.Checked != true) return;
            ChkRefIsUnique.Checked = false;
            ChkRefIsUnique.Enabled = false;
            ChkRefAddToRequest.Checked = false;
            ChkRefAddToRequest.Enabled = false;
            ChkRefAddToResponse.Checked = false;
            ChkRefAddToResponse.Enabled = false;
            ChkRefHasGet.Checked = false;
            ChkRefHasGet.Enabled = false;
            ChkRefNotNull.Checked = false;
            ChkRefNotNull.Enabled = false;

            TxtFieldName.Text = TxtRefClassName.Text.ToPlural();
            TxtFieldName.Enabled = false;
        }

        private void RdOneToMany_CheckedChanged(object sender, EventArgs e)
        {
            if (RdOneToMany.Checked != true) return;
            TxtFieldName.Text = TxtRefClassName.Text.ToPlural();
            TxtFieldName.Enabled = false;
        }

        private void RdManyToOne_CheckedChanged(object sender, EventArgs e)
        {
            if (!RdManyToOne.Checked) return;
            TxtFieldName.Text = $@"{TxtRefClassName.Text.TrimEnd()}Id";
            TxtFieldName.Enabled = false;
        }

        private void RdOneToOne_CheckedChanged(object sender, EventArgs e)
        {
            if (!RdOneToOne.Checked) return;
            TxtFieldName.Text = $@"{TxtRefClassName.Text.TrimEnd()}Id";
            TxtFieldName.Enabled = false;
        }

    }
}
