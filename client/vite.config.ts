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
				{ find: '@app', replacement: path.resolve(__dirname, 'src') },
				{ find: '@components', replacement: path.resolve(__dirname, 'src/components') },
				{ find: '@pages', replacement: path.resolve(__dirname, 'src/pages') }
			]
		}
	});
}
