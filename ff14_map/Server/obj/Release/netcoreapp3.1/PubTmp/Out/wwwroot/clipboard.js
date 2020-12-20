window.getClipboardImage = {
    setImage: function () {
        const element = document.getElementById("inputImage");
        document.querySelector("#outputImage").src = '';
        element.addEventListener("input", function input(e) {
            const temp = document.createElement("div");
            temp.innerHTML = this.innerHTML;
            const pastedImage = temp.querySelector("img");
            let base64 = null;
            if (pastedImage) {
                base64 = pastedImage.src;
                document.querySelector("#outputImage").src = base64;
            }
            this.innerHTML = "";
            this.removeEventListener("input", input);
        })
    },
    getImage: function () {
        let promise = new Promise(function (resolve, reject) {
            setTimeout(function () {
                const element = document.getElementById("outputImage");
                if (element) {
                    const base64 = document.getElementById("outputImage").src;
                    const img = new Image();
                    img.src = base64;
                    img.onload = () => {
                        if (img.width <= 640 && img.height <= 480) {
                            resolve(base64);
                            return;
                        }
                        reject(null);
                    }
                    img.onerror = () => reject(null);
                }
            });
        });
        return promise.then((val) => {
            return val;
        }).catch((error) => {
            return error;
        });
    },
    focusInput: function () {
        document.getElementById("inputImage").focus();
    },
    aim: function (map1, map2) {
        setTimeout(function (map1, map2) {
            const el1 = document.querySelector(".circle-1");
            const el2 = document.querySelector(".circle-2");
            const coefficient = 41.9;
            if (el1) {
                let x = (map1.x / coefficient) * 100;
                let y = (map1.y / coefficient) * 100;
                el1.style.left = `${x}%`;
                el1.style.top = `${y}%`;
            }
            if (el2) {
                let x = (map2.x / coefficient) * 100;
                let y = (map2.y / coefficient) * 100;
                el2.style.left = `${x}%`;
                el2.style.top = `${y}%`;
            }

        }, 0, map1, map2);
    }
}