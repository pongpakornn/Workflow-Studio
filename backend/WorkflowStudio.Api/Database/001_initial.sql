CREATE DATABASE WorkflowStudio;
GO
USE WorkflowStudio;
GO
CREATE TABLE Projects(Id uniqueidentifier NOT NULL PRIMARY KEY,Name nvarchar(200) NOT NULL,SystemType nvarchar(100) NOT NULL,Owner nvarchar(200) NOT NULL,Modules nvarchar(max) NOT NULL,UpdatedAt datetime2 NOT NULL);
CREATE TABLE WorkflowRows(Id uniqueidentifier NOT NULL PRIMARY KEY,ProjectId uniqueidentifier NOT NULL,FlowType nvarchar(40) NOT NULL,FromValue nvarchar(200) NOT NULL,ToValue nvarchar(200) NOT NULL,Label nvarchar(500) NOT NULL,SortOrder int NOT NULL,CONSTRAINT FK_WorkflowRows_Projects FOREIGN KEY(ProjectId) REFERENCES Projects(Id) ON DELETE CASCADE);
CREATE INDEX IX_WorkflowRows_ProjectId ON WorkflowRows(ProjectId);
