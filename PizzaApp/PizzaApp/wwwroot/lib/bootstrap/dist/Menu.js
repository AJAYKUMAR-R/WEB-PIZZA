

$(document).ready(() => {
    //Loading All Pizza While Page Loading
    //var arr = [];
    $.ajax({
        
        url: "/Home/MenuLoad",
        ContentType: "Application/json",
        type: "GET",
        success: (information) => {
            //Adding Dynamic Cards of Pizza with Calculate(this) event
            information.forEach((item) => {
                var data = "<div class='col-md-4 mb-3'>  <div class='card' style='width: 18rem;'> <img  src=" + item.pizzaimg + " class='card-img-top' alt='...'><div class='card-body'> <h5 class='card-title'> " + item.pizzaname + "</h5><p class=''card-text'>" + item.pizzadescription + "</p> <p>$ " + item.pizzaprice + "</p> <a class='btn btn-outline-primary' onclick = 'Calculate(this)'  id='btnorder'>Order</a></div></div></div>";
                $("#row").append(data);
            });
            //onclick for Cart hiding animation
            const loader = document.getElementById("frame");
            loader.style.display = "none";
        },
        error: (errr) => {
            alert("Error occurs");
        }
    });
    //Keyup Search When The User  type the values
    $("#txtSearch").keyup(() => {
        var txtSearch = $("#txtSearch").val();
        $.ajax({
            url: "/Home/Menu",
            dataType: "Json",
            ContentType: "Application/json",
            data: {
                txtsearch: txtSearch
            },
            type: "POST",
           
            success: (information) => {
                document.getElementById("row").innerHTML = "";
                information.forEach((item) => {
                    var data = "<div class='col-md-4  mb-3'>  <div class='card' style='width: 18rem;'> <img  src=" + item.pizzaimg + " class='card-img-top' alt='...'><div class='card-body'> <h5 class='card-title'> " + item.pizzaname + "</h5><p class=''card-text'>" + item.pizzadescription + "</p> <p>$ " + item.pizzaprice + "</p> <button class='btn btn-outline-primary' onclick = 'Calculate(this)'  id='btnorder' >Order</button></div></div></div>";
                    $("#row").append(data);
                });

               

                
            },
            error: (errr) => {
                console.log(errr);
                alert("Error occurs");
            }

        })
    });


   
    

    

    



})



//Code For Adding  Cart Async when user Click order button

function Calculate(e) {
    var element = e.previousElementSibling.previousElementSibling.previousElementSibling.textContent;

    $.ajax({
       
        url: "/Home/CartLoad",
        dataType: "Json",
        ContentType: "Application/json",
        data: {
            pizzaname: element
        },
        type: "POST",
        success: (information) => {
            //For Handling session
            if (information == 1) {
                location.href = "/Home/Logout";
            } else {
                //Cart Count For Navbar 
                document.getElementById("cartCount").innerText = information.length;
            }
           
        },
        error: (errr) => {
            console.log(errr); 
        }

    });
      
    
    
}
