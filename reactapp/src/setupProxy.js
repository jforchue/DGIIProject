const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/ContribuyentesComprobantes",
    "/weatherforecast",
];

module.exports = function (app) {
    app.use((req, res, next) => {
        console.log("Incoming request:", req.url);
        next();
    });

    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7223',
        secure: false
    });

    app.use(appProxy);
};
