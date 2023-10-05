export const getBrowserLocale = () => {
    return navigator.languages && navigator.languages.length
        ? navigator.languages[0]
        : navigator.language ?? 'en-US'
}