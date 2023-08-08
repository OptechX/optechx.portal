// wwwroot/js/load-stripe.js
function loadStripePricingTable() {
    var script = document.createElement('script');
    script.src = 'https://js.stripe.com/v3/pricing-table.js';
    script.async = true;
    document.body.appendChild(script);
}

