$(document).ready(function () {
    new EmployeeJS();
})

/**
 * Class quản lý các sự kiện cho Employee
 * CreateBy: Duong (4/1/2021)
 * */
class EmployeeJS extends BaseJS {
    constructor() {
        super();
    }
    setApiRouter() {
        this.apiRouter = "/api/v1/Employees";
    }
}