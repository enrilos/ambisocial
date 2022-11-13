import { Configuration as WebpackConfiguration } from 'webpack';
import { Configuration as WebpackDevServerConfiguration } from 'webpack-dev-server';
import MiniCssExtractPlugin from 'mini-css-extract-plugin';
import htmlWebpackPlugin from 'html-webpack-plugin';
import pathsPlugin from 'tsconfig-paths-webpack-plugin';
import path from 'path';

// @ts-ignore
import Dotenv from 'dotenv-webpack';

interface Configuration extends WebpackConfiguration {
    devServer?: WebpackDevServerConfiguration;
}

export default function (): Configuration {
    return {
        entry: '/src/index.tsx',
        mode: 'development',
        module: {
            rules: [
                {
                    test: /\.(jsx?|tsx?)$/,
                    loader: 'ts-loader'
                },
                {
                    test: /\.(s(a|c)ss|css)$/,
                    use: ['style-loader', 'css-loader', 'sass-loader']
                },
                {
                    test: /\.(jpe?g|png|svg)$/,
                    type: 'asset/resource'
                },
                {
                    test: /\.(jpe?g|png|svg)$/,
                    type: 'asset/inline'
                }
            ]
        },
        resolve: {
            extensions: ['.ts', '.tsx', '.js', '.jsx'],
            plugins: [new pathsPlugin({ configFile: path.join(__dirname, 'tsconfig.json') })]
        },
        plugins: [
            new htmlWebpackPlugin({
                template: path.join(__dirname, 'public', 'index.html'),
                inject: 'head'
            }),
            new Dotenv(),
            new MiniCssExtractPlugin()
        ],
        devServer: {
            devMiddleware: {
                publicPath: '/'
            },
            open: true
        }
    }
}