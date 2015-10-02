$(function () {
    //Web api url
    var API_URL = "http://localhost:8888/api/Ad/Get";

    //利用Get方式取得。
    $.getJSON(API_URL,
    function (data) {
        $.each(data, function (key, val) {
            var content = "";
            content += "<tr>";
            content += "<td>" + val.Cn + "</td>";
            content += "<td>" + val.Sn + "</td>";
            content += "<td>" + val.GivenName + "</td>";
            content += "<td>" + val.DisplayName + "</td>";
            content += "<td>" + val.Status + "</td>";
            content += "<tr/>";
            console.log(content);
            $('#UserList').append(content);
        });
    }).fail(
      function (jqXHR, textStatus, err) {
          alert("Error : " + err.toString());
      });
});
