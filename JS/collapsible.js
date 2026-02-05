var colls = document.getElementsByClassName("collapsible");

function closeAll() {
    for (let coll of colls) {
        coll.classList.remove("active");
        coll.nextElementSibling.style.maxHeight = null;
    }
}

for (let coll of colls) {
    coll.addEventListener("click", function (e) {
        e.preventDefault();
        let content = this.nextElementSibling;

        if (this.classList.contains("active")) {
            closeAll();
            content.style.maxHeight = 0;
        }
        else {

            this.classList.toggle("active");
            content.style.maxHeight = content.scrollHeight + "px";
        }
    });
}