function FileHandler()
{
    var spnExcelFile;
    this.init = function()
    {
        spnExcelFile = document.getElementById("btnDownload");
        spnExcelFile.onclick = function(e) { getExcelFile(); }
    }
    var getExcelFile = function() {
        
        var frmWindow = getIFrameWindow();
        var fileName = frmWindow.document.getElementById("fileName");
        fileName.value = encodeURI($("#lblFileName").text());
        var frm = frmWindow.document.getElementById("frmFile");
        frm.submit();
    }
    var getIFrameWindow = function() 
    {
        var ifr = document.getElementById("fileFrame");
        if (!ifr) 
        {
            createFrame();
        }
        var wnd = window.frames["fileFrame"];
        return wnd;
    }
    var createFrame = function() 
    {
        var frame = document.createElement("iframe");
        frame.name = "fileFrame";
        frame.id = "fileFrame";

        document.body.appendChild(frame);
        generateIFrameContent();
        frame.style.width = "0px";
        frame.style.height = "0px";
        frame.style.border = "0px";
    }
    var generateIFrameContent = function() 
    {
        var frameWindow = window.frames["fileFrame"];
        var content = "<form id='frmFile' method='post' enctype='application/data' action='/Handlers/FileHandler.ashx'><input type='text' id='fileName' name='fileName' /></form>";
        frameWindow.document.open();
        frameWindow.document.write(content);
        frameWindow.document.close();
    }


}