window.getClipboardImage = {
    setImage: function () {
        const element = document.getElementById("inputImage");
        element.addEventListener("input", function (e) {
            const temp = document.createElement("div");
            temp.innerHTML = this.innerHTML;
            const pastedImage = temp.querySelector("img");

            let base64 = null;
            if (pastedImage) {
                base64 = pastedImage.src;
                document.querySelector("#outputImage").src = base64;
            }

            this.innerHTML = "";
        })
    },
    getImage: function () {
        let promise = new Promise(function (resolve, reject) {
            setTimeout(function () {
                const element = document.getElementById("outputImage");
                if (element) {
                    const base64 = document.getElementById("outputImage").src;
                    if (element.naturalWidth > 640 || element.naturalHeight > 480) {
                        reject(null);
                        return;
                    }
                    resolve(base64);
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
}