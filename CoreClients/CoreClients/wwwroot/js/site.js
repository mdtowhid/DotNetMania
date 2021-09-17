import { signalR } from '../microsoft/signalr/dist/browser/signalr';

$(() => {
    const connection = new signalR.HubConnectionBuilder().withUrl("/signalrServer").build();
    connection.start();
    connection.on("loadProdData", function () {
        loadProdData();
    });
    loadProdData();
    function loadProdData() {
        var tr = ``;
        $.ajax({
            url: y,
            type: "GET",
            datatype: "JSON",
            data: '',
            contentType: "application/json",
            crossDomain: "true",
            headers: {
                'contentType': 'application/json',
                'Access-Control-Allow-Headers': '*'
            },
            success: function (data) {
                tr += `
                    <td>${data.ProdName}</td>
                    <td>${data.Category}</td>
                    <td>${data.UnitPrice}</td>
                    <td>${data.StockQty}</td>
                    <td>
                        <a href="../Products/Edit?id=${data.ProdId}">Edit</a>
                        <a href="../Products/Details?id=${data.ProdId}">Edit</a>
                        <a href="../Products/Delete?id=${data.ProdId}">Edit</a>
                    </td>
                `;
                $('#tableBody').html(tr);
            },
            error: function (errors) {
                console.log(errors);
            }
        });
    }
})