const { shareAll, withModuleFederationPlugin } = require('@angular-architects/module-federation/webpack');

module.exports = withModuleFederationPlugin({

  shared: {
    ...shareAll({ singleton: true, strictVersion: true, requiredVersion: 'auto' }),
  },
  sharedMappings: ['common-modules','common-interfaces','common-services','common-formatters','common-components','common-auth',
  'asp-interfaces', 'asp-services', 'asp-sforms', 'asp-updforms', 'asp-lforms', 'asp-lforms-ftr'],
});
