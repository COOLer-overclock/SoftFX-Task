Datafeeds.UDFCompatibleDatafeed.prototype.getQuotes = function (symbols, onDataCallback, onErrorCallback) {
    this._send(this._datafeedURL + '/quotes', { symbols: symbols })
		.done(function (response) {
		    var data = JSON.parse(response);
		    if (data.s === 'ok') {
		        //	JSON format is {s: "status", [{s: "symbol_status", n: "symbol_name", v: {"field1": "value1", "field2": "value2", ..., "fieldN": "valueN"}}]}
		        if (onDataCallback) {
		            onDataCallback(data.d);
		        }
		    } else {
		        if (onErrorCallback) {
		            onErrorCallback(data.errmsg);
		        }
		    }
		})
		.fail(function (arg) {
		    if (onErrorCallback) {
		        onErrorCallback('network error: ' + arg);
		    }
		});
};



localhost:213213/quotes/параметры - массив строк
