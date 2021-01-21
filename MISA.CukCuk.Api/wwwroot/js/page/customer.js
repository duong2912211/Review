$(document).ready(function () {
    new CustomerJS();
})

class CustomerJS extends BaseJS {
    constructor() {
        super();
       
    }
    setApiRouter() {
        this.apiRouter = "/api/customers";
    }
   
}

