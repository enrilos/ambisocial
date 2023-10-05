import * as path from 'path';
import react from '@vitejs/plugin-react';
import { defineConfig, loadEnv } from 'vite';

export default ({ mode }) => {
	process.env = { ...process.env, ...loadEnv(mode, process.cwd(), 'APP') };
	return defineConfig({
		plugins: [react()],
		envPrefix: 'APP_',
		server: {
			port: Number(process.env.APP_PORT ?? 4000)
		},
		resolve: {
			alias: [
				{ find: '@modules', replacement: path.resolve(__dirname, 'src/modules') },
				{ find: '@infrastructure', replacement: path.resolve(__dirname, 'src/infrastructure') }
			]
		},
		css: {
			modules: {
				localsConvention: "camelCaseOnly"
			}
		}
	});
}
