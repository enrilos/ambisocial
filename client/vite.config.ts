import react from '@vitejs/plugin-react';
import { defineConfig, loadEnv } from 'vite';
import tsconfigPaths from 'vite-tsconfig-paths';

export default ({ mode }) => {
	process.env = {...process.env, ...loadEnv(mode, process.cwd(), '')};

	return defineConfig({
		plugins: [react(), tsconfigPaths()],
		envPrefix: 'APP_',
		server: {
			port: Number(process.env.APP_PORT)
		}
	});
}
