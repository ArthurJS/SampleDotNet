//klasse node
function Node(type, par1, par2, value, yesnode, nonode) {
    this.type = type;
    this.par1 = par1;
    this.par2 = par2;
    this.value = value;
    this.yesNode = yesnode;
    this.noNode = nonode;
}
Node.prototype.getJSON = function() {
    var self = this;
    $.getJSON('')
}
//klasse leaf
function Leaf(type, climate, vegetation) {
    this.type = type;
    this.climate = climate,
    this.vegetation = vegetation;
}
//klasse parameter
function Parameter(code, description, unit) {
    this.code = code;
    this.description = description;
    this.unit = unit;
}

function generateTree(jsontable) {
    //parse data to js object

    //
}