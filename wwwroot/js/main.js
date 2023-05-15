let modalBtns = document.querySelectorAll(".card-image .modal-btn")


modalBtns.forEach(modalBtn => {
    modalBtn.addEventListener('click', function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url)
            .then(response => {

                if (response.ok) {
                    return response.text()
                }
                else {
                    alert("xeta bas verdi!")
                }
            })
            .then(data => {
                $("#quickModal .modal-dialog").html(data)
                $("#quickModal").modal('show')
            })
    })
})

let basketBtns = document.querySelectorAll("#addtobasket")
let basketItemCount = document.querySelector(".cart-total .text-number")
let itemContainer = document.querySelector(".cart-block")

basketBtns.forEach(basketBtn => {
    basketBtn.addEventListener('click', function (e) {
        e.preventDefault();

        let url = basketBtn.getAttribute("href")

        fetch(url)
            .then(response => {
                if (!response.ok) {
                    alert("xeta bas verdi!")
                }
                return response.text();
                //com
            })
            .then(data => {
                itemContainer.innerHTML = data
            })
    })
})
