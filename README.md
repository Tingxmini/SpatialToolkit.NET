# C# Spatial Analysis & GIS Algorithms Toolkit

This is an open-source C# Windows Forms application designed to demonstrate and implement a wide range of fundamental spatial analysis and computational geometry algorithms. It serves as a valuable educational tool and practical resource for students, developers, and researchers in the field of Geographic Information Systems (GIS).

The application allows users to visually draw geometric shapes (points, lines, polygons) and perform complex spatial analyses, with the results rendered directly on the canvas.

Some sample files are stored in the data folder, and users can modify them according to their needs.

## Features

The toolkit is packed with a comprehensive set of algorithms, categorized as follows:

### 📐 Spatial Measurement & Geometry
- **Distance Calculation:**
  - Between two points (Euclidean, Manhattan, Chebyshev).
  - Spherical distance on a globe.
  - Point-to-line distance.
  - Line-to-line distance.
- **Polygon Metrics:**
  - Area calculation.
  - Perimeter calculation.
  - Centroid calculation.
  - Center point calculation.
- **Fractal & Procedural Generation:**
  - Koch Curve generation.
  - Fractal Tree generation.
- **Data Visualization:**
  - Wind Rose diagram generation.
  - Linear Regression line for scatter plots.
- **3D Analysis (from TIN):**
  - TIN surface area and volume calculation.

### 🌐 TIN & Voronoi Algorithms
- **TIN & Voronoi Generation:**
  - Generate random TINs (Triangulated Irregular Networks).
  - Generate random Voronoi diagrams.
  - Incremental (point-by-point) TIN generation.
  - TIN generation using the Triangle Growth method.
- **Contouring:**
  - Generate contour lines from a TIN.
  - Smooth contour lines.
- **Convex Hull Generation.**

### 🗺️ Vector Overlay Analysis
- **Point-in-Polygon Test:** Determine if a point lies inside, outside, or on the boundary of a polygon.
- **Shortest Distance:** Calculate the shortest distance from a point to a polyline.
- **Line-Polygon Overlay:**
  - Intersection
  - Union
  - Difference (Line - Polygon and Polygon - Line)
- **Line-Line Overlay.**

### ⭕ Buffer Analysis
- **Generate Buffers:**
  - Point buffers.
  - Line buffers (left, right, and both sides).
  - Polygon buffers (inner and outer).

### ⛰️ DEM (Digital Elevation Model) Analysis
- **File Handling:** Load and parse DEM files.
- **Terrain Attribute Calculation:**
  - Slope
  - Aspect
  - Rate of change for Slope & Aspect
  - Surface Roughness
  - Terrain Relief
  - Surface Incision Depth
- **Feature Extraction:**
  - Identify peaks (summits).
  - Identify pits (depressions).
- **Viewshed Analysis:** Determine visibility between two points.

### 🔗 Network Analysis
- **Minimum Spanning Tree (MST):** Using Prim's or Kruskal's algorithm.
- **Shortest Path Algorithms:**
  - Dijkstra's Algorithm
  - Floyd-Warshall Algorithm

### 📊 Other Algorithms
- **Normal Cloud Model Generation:** For uncertainty and qualitative analysis.
- **Line Simplification:** Douglas-Peucker algorithm.
- **Clustering:** K-Means clustering algorithm.


## Usage

Once the application is running:
1.  Use the menu bar or toolstrip buttons to select an algorithm category.
2.  Input vector data by drawing directly on the main canvas or by loading data from a file (if supported).
3.  Provide any necessary parameters (e.g., buffer distance, number of clusters).
4.  Execute the algorithm.
5.  The results will be displayed visually on the canvas and/or in a results panel.

## Contributing

Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".

1.  **Fork** the Project
2.  Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3.  Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4.  Push to the Branch (`git push origin feature/AmazingFeature`)
5.  Open a **Pull Request**

Don't forget to give the project a star! Thanks again!
