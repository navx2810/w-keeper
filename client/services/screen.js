export default new class {
    breakpoint = null
    breakpoints = {
        sm: { min: 0, max: 767 },       // Modern Mobile
        md: { min: 768, max: 1007 },    // Modern Tablet
        lg: { min: 1008, max: 1200 },   // Modern Desktop
    }
    width = 0
}