function userService() {
    $(document).ready(function () {
        //GetUserAuthenticationToken();
        //Get All the Employee
        function GetAuthenticated() {
            $.ajax({
                type: "GET",
                url: "http://localhost:51100/api/employee/Authenticate",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                headers: { "Authorization": "bearer " + sessionStorage.getItem("access_token") },
                dataType: "json",
                success: function (data) {
                    alert("Authenticate --> " + data);
                }
            });
        }

        function GetAuthorized() {
            $.ajax({
                type: "GET",
                url: "http://localhost:51100/api/employee/GetEmployeeById?id=1",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                headers: { "Authorization": "bearer " + sessionStorage.getItem("access_token") },
                dataType: "json",
                success: function (data) {
                    alert("Authorized --> " + data.FirstName);
                }
            });
        }

        //Get User Token using OWIN
        function GetUserAuthenticationToken(userName, password, role, name) {
            $.ajax({
                type: "POST",
                url: "http://localhost:51100/token",
                data: "grant_type=password&username=" + userName + "&password=" + password + "&role=" + role + "&name=" + name + "",
                contentType: "application/text; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (sessionStorage) {
                        sessionStorage.setItem('access_token', data.access_token);
                    }
                    //GetAuthenticated();
                    //GetAuthorized();
                    window.location.href = window.applicationBaseUrl + 'Employee/Index';
                },
                error: function (err, obj) {
                    var t = null;
                }
            });
        }

        $('#btnLogin').click(function () {
            $.ajax({
                type: "GET",
                url: "http://localhost:51100/api/employee/CheckUserCredetial?userName=" + $('#txtUserName').val() + "&password=" + $('#txtPassword').val(),
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var jsonData = $.parseJSON(data)['CheckUserCredetialResult'];
                    GetUserAuthenticationToken(jsonData.UserName, jsonData.Password, jsonData.RoleId, jsonData.UserName);
                }
            });
        });

    })
};

userService();