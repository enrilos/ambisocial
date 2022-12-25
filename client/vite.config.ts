import react from '@vitejs/plugin-react';
import { defineConfig } from 'vite';
import tsconfigPaths from 'vite-tsconfig-paths';

export default () => {
	return defineConfig({
		plugins: [react(), tsconfigPaths()],
		envPrefix: 'APP_'
	});
}
