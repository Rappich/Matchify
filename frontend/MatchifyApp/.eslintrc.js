module.exports = {
  root: true,
  env: { browser: true, node: true },
  parser: '@typescript-eslint/parser',
  parserOptions: {
    ecmaFeatures: { jsx: true },
    ecmaVersion: 2023,
    sourceType: 'module',
  },
  plugins: ['@typescript-eslint', 'react'],
  extends: [
    'eslint:recommended',
    'plugin:@typescript-eslint/recommended',
    'plugin:react/recommended',
  ],
  settings: { react: { version: 'detect' } },
  rules: { 'react/display-name': 'off' },
  ignorePatterns: ['node_modules/**', '.expo/**', '**/*.json', '**/*.md', '**/*.css'],
};
