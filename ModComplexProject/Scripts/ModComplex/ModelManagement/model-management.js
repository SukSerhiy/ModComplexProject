$(function () {

    $('#typeSelectedList').change(function () {
        let selectedOpt = $('#typeSelectedList').find(':selected').html();
        $('#type').val(selectedOpt);
    });

    $('#Path_Exec').keyup(function () {
        $('#Type_Proj').val(getTypeProj())
    });

    $('#Path_Proj').keyup(function () {
        $('#Type_Proj').val(getTypeProj())
    });

    function getTypeProj() {
        let typeProj = "";
        let exec = $('#Path_Exec').val().trim();
        let proj = $('#Path_Proj').val().trim()
        let execType = exec.substring(exec.lastIndexOf("."));
        let projType = proj.substring(proj.lastIndexOf("."));

        if (execType == ".exe") {
            if (proj == "" || projType.length <= 1) {
                typeProj = execType;
            }
            else if (projType.length > 1) {
                typeProj = projType;
            }
        }
        return typeProj;
    }

    $('#activateModel').click(function (event) {
        let pathExec = $('#Path_Exec').val().trim();
        let pathProj = $('#Path_Proj').val().trim();
        let indexOfDot = pathProj.lastIndexOf(".");
        let typeProg = $('#Type_Proj').val().trim();
        if (indexOfDot != -1) {
            if (typeProg == ".m" && pathExec.indexOf("MATLAB") != -1) {
                pathProj = transformPath(pathProj);
                window.location = "MATLABR2009a:" + pathProj;
            }
        }
        else if (typeProg == ".exe") {
            let execName = pathExec.substring(pathExec.lastIndexOf("\\") + 1, pathExec.lastIndexOf("."));
            while (execName.indexOf(" ") != -1) {
                execName = execName.substring(0, execName.indexOf(" ")) + execName.substring(execName.indexOf(" ") + 1);
            }
            window.location = execName + ":";
        }
    });

    $('#showModelDescr').click(function () {
        let filePath = transformPath($('#Path_FullDescr').val().trim());
        if (filePath != "") {
            window.location = "MSWord:" + filePath;
        }
    });

    function transformPath(path) {
        let currPath = getCookie("currPath");
        if (currPath && path != "") {
            let pointOfEntry = path.indexOf("MODEL_COMP_HIACUSTIC");
            path = path.substring(pointOfEntry);
            let indexOfSlash = path.indexOf("\\");
            path = currPath + path.substring(indexOfSlash);
            return path;
        }
        return path;
    }
});