app.service('UIService', function () {

    this.AddMail=function (Mail) {
        if (Mail[Mail.length - 1].MailAddress != "") {
            Mail.push({ MailAddress: "" });
            return Mail;
        }          

        alert("Prethodno polje mail nije ispunjeno");
        return Mail;      
    }

    this.AddPhoneNumber = function (Number) {
        if (Number[Number.length - 1].PhoneNumber != "") {
            Number.push({ PhoneNumber: "" });
            return Number
        }
          
        alert("Prethodno polje number nije ispunjeno");
        return Number;
    }
});