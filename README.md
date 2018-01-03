# Office Connector Extension

This project allows users to complete workflow activities and perform lifecycle promotes with in Office Word and Excel.  Other Office tools can be added.  There is a common toolbar that can be reused for other Office VSTO add-ins.  

## Project Details

#### Built Using:
Aras 11.0 SP9

#### Versions Tested:
Aras 11.0 SP9
Office Word and Excel 2016

## How It Works

This is an Office add-in that uses the custom properties **Aras Office Connector** populates.  Because it is not part of **Aras Office Connector** you will be prompted to login even if you have logged into the **Aras Office Connector**.  It assumes the document itself is not going through a workflow but that it's parent item is.  For example: if the document is attached to an ECR the add-in will move the ECR through the workflow.  However, if the document is part of a lifecycle than the user also has that ability.

There is a "Common" project that contains the Office ribbon and utilities to access Aras.  To add any additional Office products you will need to create a new VSTO project based on the desired Office product and then follow the Excel and Word projects as examples.  Be sure to add the "ThisRibbonCollection" class at the end to  

#### Important!
**Always back up your code tree and database before applying an import package or code tree patch!**

### Pre-requisites

1. Aras Innovator installed (version 11.0 SP9 preferred)
2. Aras Office Connector
3. Microsoft Office products

### Install Steps

1. Open OfficeConnectorExtension.sln in Visual Studio
2. Publish the version of the Office Product you want (OfficeConnectorExtensionAddinExcel or OfficeConnectorExtensionAddinWord)
3. Install the Office Connector Extension with the published setup.exe file.

## Usage

1. Open a file form Aras using the Aras Office Connector.
2. In the "Office Connector Extension" tab the "Complete Activity" button will be enabled if there are activites for this document that need to be completed.  
3. The "Next State" pulldown will contain a list of states you have permission to promote the document to.  Select one and the Promote button will become enabled.
4. Select either the Complete Activity button or the Promote button to take any action on the file.

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

## Credits

Original Aras community project written by Frank Pampreen at Aras Corp.

Documented and published by Frank Pampreen at Aras

Contributors:
@EliJDonahue
## License

Aras Labs projects are published to Github under the MIT license. See the LICENSE file for license rights and limitations.
