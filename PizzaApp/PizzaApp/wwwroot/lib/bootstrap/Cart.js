//loading default Cart 
$(document).ready(function () {
    Cart();
});

//Delete from Cart when userr click the delete Button in Table of Cart Page
function DeleteRowInCart(e) {
    var td = e.parentElement;
    var element = td.previousElementSibling.previousElementSibling.previousElementSibling.textContent;
    $.ajax({
        url: "/Home/DeleteCart",
        dataType: "Json",
        ContentType: "Application/json",
        data: {
            pizzaname: element
        },
        type: "Get",
        success: (information) => {
            //it will return the element of Array by negelecting delete Element 
            document.getElementById("t-body").innerHTML = "";
            information.forEach((item, index) => {
                var tr = "<tr><td>" + (index + 1) + "</td><td>" + item.pizzaname + "</td><td>" + item.pizzadescription + "</td><td>" + item.pizzaprice + "</td> <td><button class='btn btn-danger'   onclick='DeleteRowInCart(this)'>Delete</button></td>";
                $("#t-body").append(tr);
            })
            Cart();
        },
        error: (errr) => {
            console.log(errr);
            alert(errr.responseText);
            alert(td);
        }
        

    });
}

//Logic for Calculating Toatl bill
function Cart() {
    var rows = document.getElementById("cartTable").getElementsByTagName('tr');
    var sum = 0;
    for (i = 1; i < rows.length - 1; i++) {
        var lastelement = rows[i].lastElementChild;
        var text = lastelement.previousElementSibling.textContent;
        sum = sum + parseInt(text);
    }

    document.getElementById("total").innerText =  sum ;
    document.getElementById("quantity").innerText = (rows.length - 2);
}

//Send totalprice and Quantity to The Action Save
function Save() {
    //Without Selecting If user select Save Button it willl throw runtime Exception
    try {

        var TotalPrice = document.getElementById("total").innerText;
        var Quantity = document.getElementById("quantity").innerText;
    }
    catch {

        return;
    }
    $.ajax({
        url: "/Home/Save",
        dataType: "Json",
        ContentType: "Application/json",
        data: {
            "Total": TotalPrice,
            "TotalQuantity": Quantity,
        },
        Type: "GET",
        success: (information) => {
            //Success it will Print delvery Message
            if (information == 0) {
                document.getElementById("cartTable").innerHTML = "";
                var h1 = "<h1 text-align='center' class='m-5'>Ordered Placed Deliverd 20 minutes<h1/>";
                $("#heading").append(h1);
            } else {
                //internal error occurs 
                document.getElementById("cartTable").innerHTML = "";
                var h1 = "<h1 text-align='center' class='m-5'>Order Can't be placed due to internal error  <h1/>";
                $("#heading").append(h1);
            }
           
        },
        error: (errr) => {
            console.log(errr);
            alert(errr.responseText);
            
        }


    });

}