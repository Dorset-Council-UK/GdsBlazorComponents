const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const CopyPlugin = require('copy-webpack-plugin');

module.exports = {
    entry: {
        gds: './Scripts/gds.ts'
    },
    resolve: {
        extensions: ['.ts', '.js']
    },
    experiments: {
        outputModule: true,
    },
    output: {
        filename: '[name].js',
        path: path.resolve(__dirname, 'wwwroot'),
        library: {
            type: 'module'
        },
        clean: {
            keep: /^(css\/.*\.css)$/ // Keep and any css files under the css folder
        }
    },
    module: {
        rules: [
            {
                test: /\.([cm]?ts|tsx)$/,
                loader: 'ts-loader',
                exclude: /node_modules/,
            },
            {
                test: /\.s[ac]ss$/i,
                use: [
                    MiniCssExtractPlugin.loader, // Extracts CSS into separate files
                    {
                        loader: 'css-loader', // Creates `style` nodes from JS strings
                        options: {
                            url: false // This tells css-loader not to resolve url() paths
                        }
                    },
                    {
                        loader: 'sass-loader', // Compiles Sass to CSS
                        options: {
                            sassOptions: {
                                quietDeps: true,
                                includePaths: ['node_modules']
                            }
                        }
                    }
                ]
            },
            {
                test: /\.css$/i, // Extracts imported CSS in TypeScript into separate files
                use: [
                    MiniCssExtractPlugin.loader,
                    {
                        loader: 'css-loader', // Creates `style` nodes from JS strings
                        options: {
                            url: false // This tells css-loader not to resolve url() paths
                        }
                    },
                ]
            }
        ]
    },
    plugins: [
        // Copy assets to the output folder
        new CopyPlugin({
            patterns: [
                { from: 'Scripts/images', to: 'images' },
            ]
        }),
        // Extract the CSS into a separate file
        new MiniCssExtractPlugin({
            filename: '[name].css'
        })
    ]
}