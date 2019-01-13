
'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');
var livereload = require('gulp-livereload');
gulp.task('sass', function () {
    return gulp.src('wwwroot/dist/css/scss/site.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/dist/css/scss'))
        .pipe(livereload());
});
// Watch Files For Changes
gulp.task('watch', function () {
    livereload.listen();
    gulp.watch(['wwwroot/dist/css/scss/**/*.scss'], gulp.series('sass'));
});