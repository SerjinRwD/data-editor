/// <binding BeforeBuild='copy:main' />
module.exports = function (grunt) {
    grunt.initConfig({
        copy: {
            main: {
                files: [
                    { expand: true, cwd: 'node_modules/@fortawesome/fontawesome-free/css', src: ['**'], dest: 'wwwroot/assets/fontawesome-free/css' },
                    { expand: true, cwd: 'node_modules/@fortawesome/fontawesome-free/webfonts', src: ['**'], dest: 'wwwroot/assets/fontawesome-free/webfonts' },
                    { expand: true, cwd: 'node_modules/bulma/css', src: ['**'], dest: 'wwwroot/assets/bulma/' },
                    { expand: true, cwd: 'node_modules/animate.css', src: ['*.css'], dest: 'wwwroot/assets/animate/' }
                ]
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-copy');
};