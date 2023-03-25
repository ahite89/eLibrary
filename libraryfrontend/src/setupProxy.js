const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/library",
];

module.exports = function (app) {
    const appProxy = createProxyMiddleware(context, {
        target: 'https://localhost:7010',
        secure: false
    });

    app.use(appProxy);
};
