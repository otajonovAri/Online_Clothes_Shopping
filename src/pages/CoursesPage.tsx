import { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import { Search, Filter, Star, Clock, Users, BookOpen } from 'lucide-react'
import { motion } from 'framer-motion'
import type { Course } from '../types'

export function CoursesPage() {
  const [courses, setCourses] = useState<Course[]>([])
  const [loading, setLoading] = useState(true)
  const [searchTerm, setSearchTerm] = useState('')
  const [selectedCategory, setSelectedCategory] = useState('all')
  const [selectedLevel, setSelectedLevel] = useState('all')
  const [sortBy, setSortBy] = useState('popular')

  // Mock data - replace with API call
  useEffect(() => {
    const mockCourses: Course[] = [
      {
        id: '1',
        title: 'React va TypeScript asoslari',
        description: 'Zamonaviy web dasturlash texnologiyalarini o\'rganing',
        shortDescription: 'React va TypeScript bilan professional web ilovalar yarating',
        thumbnail: 'https://images.pexels.com/photos/11035380/pexels-photo-11035380.jpeg?auto=compress&cs=tinysrgb&w=500',
        price: 299000,
        duration: 40,
        level: 'beginner',
        category: 'Programming',
        tags: ['React', 'TypeScript', 'JavaScript'],
        instructorId: '1',
        instructor: {
          id: '1',
          email: 'alisher@example.com',
          firstName: 'Alisher',
          lastName: 'Karimov',
          role: 'instructor',
          bio: 'Senior Frontend Developer',
          expertise: ['React', 'TypeScript'],
          courses: [],
          rating: 4.8,
          totalStudents: 1250,
          createdAt: '2024-01-01',
          updatedAt: '2024-01-01',
        },
        lessons: [],
        enrolledStudents: 1250,
        rating: 4.8,
        reviews: [],
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
      {
        id: '2',
        title: 'Python bilan Data Science',
        description: 'Ma\'lumotlar tahlili va mashina o\'rganish asoslari',
        shortDescription: 'Python yordamida data science va ML o\'rganing',
        thumbnail: 'https://images.pexels.com/photos/1181671/pexels-photo-1181671.jpeg?auto=compress&cs=tinysrgb&w=500',
        price: 399000,
        duration: 60,
        level: 'intermediate',
        category: 'Data Science',
        tags: ['Python', 'Data Science', 'Machine Learning'],
        instructorId: '2',
        instructor: {
          id: '2',
          email: 'malika@example.com',
          firstName: 'Malika',
          lastName: 'Tosheva',
          role: 'instructor',
          bio: 'Data Scientist',
          expertise: ['Python', 'Data Science'],
          courses: [],
          rating: 4.9,
          totalStudents: 980,
          createdAt: '2024-01-01',
          updatedAt: '2024-01-01',
        },
        lessons: [],
        enrolledStudents: 980,
        rating: 4.9,
        reviews: [],
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
      {
        id: '3',
        title: 'UI/UX Design Masterclass',
        description: 'Professional dizayn ko\'nikmalari va zamonaviy vositalar',
        shortDescription: 'UI/UX dizayn bo\'yicha to\'liq kurs',
        thumbnail: 'https://images.pexels.com/photos/196644/pexels-photo-196644.jpeg?auto=compress&cs=tinysrgb&w=500',
        price: 349000,
        duration: 35,
        level: 'beginner',
        category: 'Design',
        tags: ['UI/UX', 'Figma', 'Design'],
        instructorId: '3',
        instructor: {
          id: '3',
          email: 'sardor@example.com',
          firstName: 'Sardor',
          lastName: 'Rahimov',
          role: 'instructor',
          bio: 'Senior UI/UX Designer',
          expertise: ['UI/UX', 'Figma'],
          courses: [],
          rating: 4.7,
          totalStudents: 750,
          createdAt: '2024-01-01',
          updatedAt: '2024-01-01',
        },
        lessons: [],
        enrolledStudents: 750,
        rating: 4.7,
        reviews: [],
        createdAt: '2024-01-01',
        updatedAt: '2024-01-01',
      },
    ]

    setTimeout(() => {
      setCourses(mockCourses)
      setLoading(false)
    }, 1000)
  }, [])

  const categories = [
    { value: 'all', label: 'Barcha kategoriyalar' },
    { value: 'Programming', label: 'Dasturlash' },
    { value: 'Data Science', label: 'Data Science' },
    { value: 'Design', label: 'Dizayn' },
    { value: 'Marketing', label: 'Marketing' },
    { value: 'Business', label: 'Biznes' },
  ]

  const levels = [
    { value: 'all', label: 'Barcha darajalar' },
    { value: 'beginner', label: 'Boshlang\'ich' },
    { value: 'intermediate', label: 'O\'rta' },
    { value: 'advanced', label: 'Yuqori' },
  ]

  const sortOptions = [
    { value: 'popular', label: 'Mashhurlik bo\'yicha' },
    { value: 'rating', label: 'Reyting bo\'yicha' },
    { value: 'price-low', label: 'Arzon narx' },
    { value: 'price-high', label: 'Qimmat narx' },
    { value: 'newest', label: 'Eng yangi' },
  ]

  const filteredCourses = courses.filter(course => {
    const matchesSearch = course.title.toLowerCase().includes(searchTerm.toLowerCase()) ||
                         course.description.toLowerCase().includes(searchTerm.toLowerCase())
    const matchesCategory = selectedCategory === 'all' || course.category === selectedCategory
    const matchesLevel = selectedLevel === 'all' || course.level === selectedLevel
    
    return matchesSearch && matchesCategory && matchesLevel
  })

  const sortedCourses = [...filteredCourses].sort((a, b) => {
    switch (sortBy) {
      case 'rating':
        return b.rating - a.rating
      case 'price-low':
        return a.price - b.price
      case 'price-high':
        return b.price - a.price
      case 'newest':
        return new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime()
      default: // popular
        return b.enrolledStudents - a.enrolledStudents
    }
  })

  if (loading) {
    return (
      <div className="min-h-screen bg-secondary-50 py-12">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="animate-pulse">
            <div className="h-8 bg-secondary-200 rounded w-1/4 mb-8"></div>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
              {[...Array(6)].map((_, i) => (
                <div key={i} className="bg-white rounded-xl p-6">
                  <div className="h-48 bg-secondary-200 rounded mb-4"></div>
                  <div className="h-4 bg-secondary-200 rounded mb-2"></div>
                  <div className="h-4 bg-secondary-200 rounded w-3/4"></div>
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    )
  }

  return (
    <div className="min-h-screen bg-secondary-50 py-12">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        {/* Header */}
        <div className="mb-8">
          <h1 className="text-3xl lg:text-4xl font-bold text-secondary-900 mb-4">
            Kurslar
          </h1>
          <p className="text-xl text-secondary-600">
            Professional ko'nikmalarni o'rganing va karyerangizni rivojlantiring
          </p>
        </div>

        {/* Filters */}
        <div className="bg-white rounded-xl p-6 mb-8 shadow-sm">
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4">
            {/* Search */}
            <div className="relative">
              <Search className="absolute left-3 top-1/2 transform -translate-y-1/2 w-4 h-4 text-secondary-400" />
              <input
                type="text"
                placeholder="Kurslar qidirish..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                className="input pl-10"
              />
            </div>

            {/* Category Filter */}
            <select
              value={selectedCategory}
              onChange={(e) => setSelectedCategory(e.target.value)}
              className="input"
            >
              {categories.map(category => (
                <option key={category.value} value={category.value}>
                  {category.label}
                </option>
              ))}
            </select>

            {/* Level Filter */}
            <select
              value={selectedLevel}
              onChange={(e) => setSelectedLevel(e.target.value)}
              className="input"
            >
              {levels.map(level => (
                <option key={level.value} value={level.value}>
                  {level.label}
                </option>
              ))}
            </select>

            {/* Sort */}
            <select
              value={sortBy}
              onChange={(e) => setSortBy(e.target.value)}
              className="input"
            >
              {sortOptions.map(option => (
                <option key={option.value} value={option.value}>
                  {option.label}
                </option>
              ))}
            </select>
          </div>
        </div>

        {/* Results Count */}
        <div className="mb-6">
          <p className="text-secondary-600">
            {sortedCourses.length} ta kurs topildi
          </p>
        </div>

        {/* Courses Grid */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
          {sortedCourses.map((course, index) => (
            <motion.div
              key={course.id}
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 0.6, delay: index * 0.1 }}
              className="card-hover p-0 overflow-hidden group"
            >
              <div className="relative">
                <img
                  src={course.thumbnail}
                  alt={course.title}
                  className="w-full h-48 object-cover group-hover:scale-105 transition-transform duration-300"
                />
                <div className="absolute top-4 left-4">
                  <span className="px-3 py-1 bg-primary-600 text-white text-xs font-medium rounded-full">
                    {course.level === 'beginner' ? 'Boshlang\'ich' : 
                     course.level === 'intermediate' ? 'O\'rta' : 'Yuqori'}
                  </span>
                </div>
                <div className="absolute top-4 right-4">
                  <span className="px-3 py-1 bg-black/50 text-white text-xs font-medium rounded-full">
                    {course.category}
                  </span>
                </div>
              </div>
              
              <div className="p-6">
                <h3 className="text-xl font-semibold text-secondary-900 mb-2 group-hover:text-primary-600 transition-colors">
                  {course.title}
                </h3>
                <p className="text-secondary-600 mb-4 line-clamp-2">
                  {course.shortDescription}
                </p>
                
                <div className="flex items-center space-x-4 mb-4 text-sm text-secondary-500">
                  <div className="flex items-center space-x-1">
                    <Clock className="w-4 h-4" />
                    <span>{course.duration} soat</span>
                  </div>
                  <div className="flex items-center space-x-1">
                    <Users className="w-4 h-4" />
                    <span>{course.enrolledStudents}</span>
                  </div>
                </div>
                
                <div className="flex items-center justify-between mb-4">
                  <div className="flex items-center space-x-1">
                    <Star className="w-4 h-4 text-yellow-400 fill-current" />
                    <span className="text-sm font-medium text-secondary-700">
                      {course.rating}
                    </span>
                  </div>
                  <div className="text-sm text-secondary-600">
                    {course.instructor.firstName} {course.instructor.lastName}
                  </div>
                </div>
                
                <div className="flex items-center justify-between">
                  <div className="text-2xl font-bold text-primary-600">
                    {course.price.toLocaleString()} so'm
                  </div>
                  <Link
                    to={`/courses/${course.id}`}
                    className="btn-primary text-sm"
                  >
                    Batafsil
                  </Link>
                </div>
              </div>
            </motion.div>
          ))}
        </div>

        {/* Empty State */}
        {sortedCourses.length === 0 && (
          <div className="text-center py-12">
            <BookOpen className="w-16 h-16 text-secondary-300 mx-auto mb-4" />
            <h3 className="text-xl font-semibold text-secondary-900 mb-2">
              Kurslar topilmadi
            </h3>
            <p className="text-secondary-600 mb-6">
              Qidiruv shartlaringizni o'zgartiring yoki barcha kurslarni ko'ring
            </p>
            <button
              onClick={() => {
                setSearchTerm('')
                setSelectedCategory('all')
                setSelectedLevel('all')
              }}
              className="btn-primary"
            >
              Filtrlarni tozalash
            </button>
          </div>
        )}
      </div>
    </div>
  )
}